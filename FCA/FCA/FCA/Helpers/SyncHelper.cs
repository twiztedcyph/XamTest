using FCA.Models;
using FCA.Shared;
using ICSharpCode.SharpZipLib.Zip;
using PCLStorage;
using Pellcomp.Vs.Mobile.FormCaptureApp.lib;
using Plugin.Connectivity;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamTest.Helpers;

namespace FCA.Helpers
{
    public class SyncHelper
    {
        public const string TemplateFolder = "Templates";
        public static string FormsFolder = "Forms";
        public const string SignaturesFolder = "Signatures";

        public static async Task SyncAll(Label lblProgress, ActivityIndicator aiIndicator)
        {
            if (await CheckForWifiOnly() || Settings.IsNewLogin)
            {
                lblProgress.Text = "";
                lblProgress.IsVisible = true;
                if (aiIndicator != null)
                    aiIndicator.IsRunning = true;

                await CheckServiceVersion(lblProgress);

                await GetStaticBaseData(lblProgress);

                await UpdateFormOwnership(lblProgress);

                await DownloadUserReviews(lblProgress);

                await UploadForms(lblProgress);

                await ClearUnwantedForms(lblProgress);

                await DownloadForms(lblProgress);

                await SyncOrgs(false, lblProgress);
            }
        }

        private static async Task CheckServiceVersion(Label lblProgress)
        {
            lblProgress.Text = "Checking Web Service version";

            GenericResponse<Dictionary<string, string>> result = await App.soapService.GetSystemInfo();

            Settings.WebServiceVersion = result.Data["Web Service DLL Version"];

            if (!Settings.ServiceSupports(Settings.ServiceFeatures.MinimumVersion))
            {
                throw new NotSupportedException($"Service version: {Settings.WebServiceVersion} does not meet the minimum supported version of " +
                    $"{Settings.ServiceFeatures.MinimumVersion}. Please contact your system administrator to arrange an update of the web service");
            }
        }

        public static async Task<IFolder> ForceDirectory(string FolderName)
        {
            IFolder localStorage = FileSystem.Current.LocalStorage;
            FolderName = FolderName.Replace(localStorage.Path, string.Empty); //ensure passed in folder paths are routed from local storage
            if (!string.IsNullOrEmpty(FolderName))
            {
                string[] folders = FolderName.Split('\\');

                foreach (string folder in folders)
                {
                    localStorage = await localStorage.CreateFolderAsync(folder, CreationCollisionOption.OpenIfExists);
                }
            }
            return localStorage;
        }

        private static async Task<string> DownloadFile(string Guid, string FileName, string FolderName)
        {
            IFolder localStorage = await ForceDirectory(FolderName);

            GenericResponse<byte[]> response = await App.soapService.DownloadFile(Guid);
            string sResult = string.Empty;
            try
            {
                IFile downloadedFile = await localStorage.CreateFileAsync(FileName, CreationCollisionOption.ReplaceExisting);
                Stream fileStream = new MemoryStream(response.Data);
                using (Stream sNew = await downloadedFile.OpenAsync(PCLStorage.FileAccess.ReadAndWrite))
                {
                    fileStream.CopyTo(sNew);
                }

                //Check the file exists and return its name.
                IFile attachFile = await localStorage.GetFileAsync(FileName);
                sResult = attachFile.Path;
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error", "Error With File:  " + ex.Message, "OK");
            }
            return sResult;
        }

        private static void SetMessage(Label lblProgress, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                lblProgress.Text = message;
            });
        }

        private static async Task DownloadForms(Label lblProgress)
        {
            if (Settings.DebugOptions.ProcessSync(Settings.DebugOptions.DownloadForms))
            {
                lblProgress.Text = "Fetching Your Forms";

                GenericResponse<List<DBFormInstance>> forms = await App.soapService.GetForms();

                List<string> GUIDsForOrgCheck = new List<string>();
                List<DBFormInstance> formsForSignatureCheck = new List<DBFormInstance>();
                lblProgress.Text = "Saving Your Forms";
                try
                {
                    //TODO: Should we be doing connection based database access here?  As well as throughout this class...
                    await App.DB.AsyncDb.RunInTransactionAsync((SQLiteConnection connection) =>
                    {
                        foreach (DBFormInstance wsForm in forms.Data)
                        {
                            SetMessage(lblProgress, "Saving Your Forms [Processing Form " + wsForm.FormInstanceID + "]");
                            DBFormInstance dbForm = connection.Table<DBFormInstance>().Where(f => f.FormInstanceID == wsForm.FormInstanceID).FirstOrDefault();
                            if (wsForm.Status == fldFormCapCommon.FORM_STATUS_ADMINDELETED)
                            {
                                if (dbForm != null)
                                {
                                    foreach (DBFormField dbField in dbForm.Fields.Values)
                                    {
                                        connection.Delete(dbField);
                                    }
                                    foreach (DBFormInstanceAttachment dbAttach in dbForm.Attachments)
                                    {
                                        connection.Delete(dbAttach);
                                    }
                                    connection.Delete(dbForm);
                                }
                            }
                            else if (dbForm == null)
                            {
                                SetMessage(lblProgress, "Saving Your Forms [Inserting Form " + wsForm.FormInstanceID + "]");
                                connection.Insert(wsForm);
                                formsForSignatureCheck.Add(wsForm);
                                foreach (DBFormField wsField in wsForm.Fields.Values)
                                {
                                    DBFormField dbField = connection.Table<DBFormField>().Where(f => f.RecGUID == wsField.RecGUID).FirstOrDefault();
                                    SetMessage(lblProgress, "Saving Your Forms [Inserting Form " + wsForm.FormInstanceID + " - field " + wsField.RecGUID + "]");
                                    if (dbField != null)
                                        connection.Update(wsField);
                                    else
                                    {
                                        connection.Insert(wsField);
                                    }
                                    if (FieldNameHelper.IsOrganisationQuestion(wsField.FieldName, null) && !string.IsNullOrWhiteSpace(wsField.FieldValue))
                                    {
                                        GUIDsForOrgCheck.Add(wsField.FieldValue);
                                    }
                                }
                                foreach (DBFormInstanceAttachment wsAttach in wsForm.Attachments)
                                {
                                    DBFormInstanceAttachment dbAttach = connection.Table<DBFormInstanceAttachment>().Where(f => f.IndexID == wsAttach.IndexID).FirstOrDefault();
                                    SetMessage(lblProgress, "Saving Your Forms [Inserting Form " + wsForm.FormInstanceID + " - attachment " + wsAttach.IndexID + "]");
                                    if (dbAttach != null)
                                        connection.Update(wsAttach);
                                    else
                                        connection.Insert(wsAttach);
                                    if (!string.IsNullOrEmpty(wsAttach.FileGUID))
                                    {
                                        SetMessage(lblProgress, "Saving Your Forms [Inserting Form " + wsForm.FormInstanceID + " - attachment " + wsAttach.IndexID + " Download]");
                                        DownloadAttachmentFile(wsAttach);
                                    }
                                }
                            }
                            else if ((wsForm.ModifiedDate > dbForm.ModifiedDate)
                                    && (wsForm.ModifiedDate > dbForm.LastUploaded))
                            {
                                dbForm.Title = wsForm.Title;
                                dbForm.CreatedDate = wsForm.CreatedDate;
                                dbForm.CreatedBy = wsForm.CreatedBy;
                                dbForm.ModifiedDate = wsForm.ModifiedDate;
                                dbForm.ModifiedBy = wsForm.ModifiedBy;
                                dbForm.OwnedBy = wsForm.OwnedBy;
                                dbForm.Status = wsForm.Status;
                                if (dbForm.EmpSignatureFileGUID != wsForm.EmpSignatureFileGUID)
                                    dbForm.EmpSignatureData = string.Empty;
                                dbForm.EmpSignatureFileGUID = wsForm.EmpSignatureFileGUID;
                                if (dbForm.LearnerSignatureFileGUID != wsForm.LearnerSignatureFileGUID)
                                    dbForm.LearnerSignatureData = string.Empty;
                                dbForm.LearnerSignatureFileGUID = wsForm.LearnerSignatureFileGUID;
                                if (dbForm.UserSignatureFileGUID != wsForm.UserSignatureFileGUID)
                                    dbForm.UserSignatureData = string.Empty;
                                dbForm.UserSignatureFileGUID = wsForm.UserSignatureFileGUID;

                                if (dbForm.EmpBSignatureFileGUID != wsForm.EmpBSignatureFileGUID)
                                    dbForm.EmpBSignatureData = string.Empty;
                                dbForm.EmpBSignatureFileGUID = wsForm.EmpBSignatureFileGUID;

                                if (dbForm.EmpCSignatureFileGUID != wsForm.EmpCSignatureFileGUID)
                                    dbForm.EmpCSignatureData = string.Empty;
                                dbForm.EmpCSignatureFileGUID = wsForm.EmpCSignatureFileGUID;

                                if (dbForm.OfficerASignatureFileGUID != wsForm.OfficerASignatureFileGUID)
                                    dbForm.OfficerASignatureData = string.Empty;
                                dbForm.OfficerASignatureFileGUID = wsForm.OfficerASignatureFileGUID;

                                if (dbForm.OfficerBSignatureFileGUID != wsForm.OfficerBSignatureFileGUID)
                                    dbForm.OfficerBSignatureData = string.Empty;
                                dbForm.OfficerBSignatureFileGUID = wsForm.OfficerBSignatureFileGUID;

                                //Other signatures here
                                dbForm.LastUploaded = DateTime.MinValue;
                                dbForm.OriginatingForm = wsForm.OriginatingForm;
                                dbForm.CreateVersion = wsForm.CreateVersion;
                                dbForm.LastModVersion = wsForm.LastModVersion;
                                dbForm.HOFeedBack = wsForm.HOFeedBack;
                                dbForm.CustomFormID = wsForm.CustomFormID;
                                dbForm.SourceApplicID = wsForm.SourceApplicID;
                                dbForm.SourceCRMEventID = wsForm.SourceCRMEventID;

                                formsForSignatureCheck.Add(dbForm);

                                SetMessage(lblProgress, "Saving Your Forms [Updating Form " + dbForm.FormInstanceID + "]");
                                connection.Update(dbForm);

                                dbForm.Fields = new Dictionary<string, DBFormField>();
                                List<DBFormField> slFields = connection.Table<DBFormField>().Where(f => f.FormInstanceID == wsForm.FormInstanceID).ToList();
                                foreach (DBFormField field in slFields)
                                {
                                    dbForm.Fields.Add(field.FieldName, field);
                                    if (FieldNameHelper.IsOrganisationQuestion(field.FieldName, null) && !string.IsNullOrWhiteSpace(field.FieldValue))
                                    {
                                        GUIDsForOrgCheck.Add(field.FieldValue);
                                    }
                                }
                                foreach (KeyValuePair<string, DBFormField> wsField in wsForm.Fields)
                                {
                                    DBFormField dbField = null;
                                    if (dbForm.Fields.ContainsKey(wsField.Key))
                                        dbField = dbForm.Fields[wsField.Key];
                                    if (dbField != null)
                                    {
                                        SetMessage(lblProgress, "Saving Your Forms [Updating Form " + dbForm.FormInstanceID + " Updating Field " + dbField.RecGUID + "]");
                                        dbField.FieldValue = wsField.Value.FieldValue;
                                        dbField.FieldType = wsField.Value.FieldType;
                                        connection.Update(dbField);
                                    }
                                    else
                                    {
                                        SetMessage(lblProgress, "Saving Your Forms [Updating Form " + dbForm.FormInstanceID + " Inserting Field " + dbField.RecGUID + "]");
                                        connection.Insert(wsField.Value);
                                    }
                                }

                                try
                                {
                                    //ToDo: Instead of getting a list of all attachments in database, just check each one and insert, or update.

                                    SetMessage(lblProgress, "Saving Your Forms [Updating Form " + dbForm.FormInstanceID + " Checking Attachments]");
                                    dbForm.Attachments = connection.Table<DBFormInstanceAttachment>().Where(f => f.FormInstanceID == wsForm.FormInstanceID).ToList();
                                    Dictionary<string, DBFormInstanceAttachment> slAttach = new Dictionary<string, DBFormInstanceAttachment>();
                                    foreach (DBFormInstanceAttachment dbAttachTemp in dbForm.Attachments)
                                    {
                                        slAttach.Add(dbAttachTemp.IndexID, dbAttachTemp);
                                    }
                                    foreach (DBFormInstanceAttachment attach in wsForm.Attachments)
                                    {
                                        DBFormInstanceAttachment formInstance = connection.Table<DBFormInstanceAttachment>().Where(x => x.IndexID == attach.IndexID).FirstOrDefault();

                                        if (formInstance != null)
                                        {
                                            SetMessage(lblProgress, "Saving Your Forms [Updating Form " + dbForm.FormInstanceID + " Updating Attachment " + attach.IndexID + "]");
                                            formInstance.FileGUID = attach.FileGUID;
                                            formInstance.FileName = attach.FileName;
                                            formInstance.Name = attach.Name;
                                            connection.Update(formInstance, typeof(DBFormInstanceAttachment));
                                        }
                                        else
                                        {
                                            SetMessage(lblProgress, "Saving Your Forms [Updating Form " + dbForm.FormInstanceID + " Inserting Attachment " + attach.IndexID + "]");
                                            connection.Insert(attach);
                                        }

                                        if (!string.IsNullOrEmpty(attach.FileGUID))
                                        {
                                            SetMessage(lblProgress, "Saving Your Forms [Updating Form " + dbForm.FormInstanceID + " Downloading Attachment " + attach.IndexID + "]");
                                            DownloadAttachmentFile(attach);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    //Debug.WriteLine(ex.Message);
                                    throw;
                                }
                            }
                        }
                    });

                    HashSet<DBFormInstance> formsToUpdate = new HashSet<DBFormInstance>();
                    foreach (DBFormInstance form in formsForSignatureCheck)
                    {
                        if (!string.IsNullOrEmpty(form.LearnerSignatureFileGUID) && string.IsNullOrEmpty(form.LearnerSignatureData))
                        {
                            form.LearnerSignatureData = DownloadSignatureFile(form.FormInstanceID, form.LearnerSignatureFileGUID, RequiredSignature.rsLearner);
                            formsToUpdate.Add(form);
                        }
                        if (!string.IsNullOrEmpty(form.UserSignatureFileGUID) && string.IsNullOrEmpty(form.UserSignatureData))
                        {
                            form.UserSignatureData = DownloadSignatureFile(form.FormInstanceID, form.UserSignatureFileGUID, RequiredSignature.rsUser);
                            formsToUpdate.Add(form);
                        }
                        if (!string.IsNullOrEmpty(form.EmpSignatureFileGUID) && string.IsNullOrEmpty(form.EmpSignatureData))
                        {
                            form.EmpSignatureData = DownloadSignatureFile(form.FormInstanceID, form.EmpSignatureFileGUID, RequiredSignature.rsEmployer);
                            formsToUpdate.Add(form);
                        }
                        if (!string.IsNullOrEmpty(form.EmpBSignatureData) && string.IsNullOrEmpty(form.EmpBSignatureData))
                        {
                            form.EmpBSignatureData = DownloadSignatureFile(form.FormInstanceID, form.EmpBSignatureFileGUID, RequiredSignature.rsEmployerB);
                            formsToUpdate.Add(form);
                        }
                        if (!string.IsNullOrEmpty(form.EmpCSignatureData) && string.IsNullOrEmpty(form.EmpCSignatureData))
                        {
                            form.EmpCSignatureData = DownloadSignatureFile(form.FormInstanceID, form.EmpCSignatureFileGUID, RequiredSignature.rsEmployerC);
                            formsToUpdate.Add(form);
                        }
                        if (!string.IsNullOrEmpty(form.OfficerASignatureData) && string.IsNullOrEmpty(form.OfficerASignatureFileGUID))
                        {
                            form.OfficerASignatureData = DownloadSignatureFile(form.FormInstanceID, form.OfficerASignatureFileGUID, RequiredSignature.rsOfficerA);
                            formsToUpdate.Add(form);
                        }
                        if (!string.IsNullOrEmpty(form.OfficerBSignatureData) && string.IsNullOrEmpty(form.OfficerBSignatureFileGUID))
                        {
                            form.OfficerBSignatureData = DownloadSignatureFile(form.FormInstanceID, form.OfficerBSignatureFileGUID, RequiredSignature.rsOfficerB);
                            formsToUpdate.Add(form);
                        }
                    }

                    if (formsToUpdate.Count > 0)
                    {
                        await App.DB.AsyncDb.RunInTransactionAsync((SQLiteConnection connection) =>
                        {
                            foreach (DBFormInstance wsForm in formsToUpdate)
                            {
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    lblProgress.Text = "Saving Your Forms [Form To Update " + wsForm.FormInstanceID + "]";
                                });
                                connection.Update(wsForm);
                            }
                        });
                    }

                    foreach (string GUID in GUIDsForOrgCheck.Distinct())
                    {
                        //For each guid in our list of guids to check, check if an org with that guid exists in the local database and if not then download and save it.
                        DBOrganisation org = await App.DB.GetOrganisationByGUID(GUID);
                        if (org == null)
                        {
                            GenericResponse<DBOrganisation> orgResponse = await App.soapService.GetSingleOrganisationByGUID(GUID);
                            lblProgress.Text = "Fetching and saving used organisation: " + orgResponse.Data.Name;
                            await App.DB.SaveOrganisation(orgResponse.Data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    App.Current.MainPage.DisplayException("Download forms (" + lblProgress.Text + ")", ex);
                    throw;
                }
            }
        }

        private static async Task<bool> FileExists(string fileDirectory, string fileName)
        {
            IFile file = null;

            try
            {
                string path = PortablePath.Combine(FileSystem.Current.LocalStorage.Path, fileDirectory, fileName);
                file = await FileSystem.Current.GetFileFromPathAsync(path);
                return file != null;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private static void DownloadAttachmentFile(DBFormInstanceAttachment attach)
        {
            Task.Run(
                () => ForceDirectory(FormsFolder)
            );
            string fileDir = PortablePath.Combine(FormsFolder, attach.FormInstanceID);
            Task<bool> checkFileExists = Task.Run(() => FileExists(fileDir, attach.FileName));
            if (!string.IsNullOrEmpty(attach.FileGUID) && !checkFileExists.Result)
            {
                string zipName = attach.FileName + ".zip";
                attach.FileName = DownloadAndUnzipFile(attach.FileGUID, zipName, fileDir);
            }
        }

        private static string DownloadSignatureFile(string formInstanceID, string fileGUID, RequiredSignature signatureType)
        {
            Debug.WriteLine("DownloadSignatureFile: " + formInstanceID + "_" + fileGUID);
            string fileDir = PortablePath.Combine(FormsFolder, formInstanceID, SignaturesFolder);
            Task.Run(() => ForceDirectory(fileDir));
            string fileName = Task.Run(() => App.soapService.GetFileData(fileGUID)).Result.Data["FileName"];

            if (fileName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
            {
                return DownloadAndUnzipFile(fileGUID, fileName, fileDir);
            }
            else
            {
                return Task.Run(() => DownloadFile(fileGUID, fileName, fileDir)).Result;
            }
        }

        private static string DownloadAndUnzipFile(string fileGUID, string zipName, string fileDir)
        {
            Guid tempGuid = new Guid();
            string filePath = string.Empty;
            if (Guid.TryParse(fileGUID, out tempGuid))
            {
                Task<string> downloadFile = Task.Run(() => DownloadFile(fileGUID, zipName, fileDir));
                filePath = downloadFile.Result;

                if (!string.IsNullOrEmpty(filePath))
                {
                    FastZip fastZip = new FastZip();
                    fastZip.ExtractZip(filePath, PortablePath.Combine(FileSystem.Current.LocalStorage.Path, fileDir), null);
                    filePath = filePath.Replace(".zip", "");

                    IFile file = Task.Run(() => FileSystem.Current.GetFileFromPathAsync(filePath)).Result;
                    return file != null ? filePath : string.Empty;
                }
            }

            return filePath;
        }

        private static async Task UploadForms(Label lblProgress)
        {
            lblProgress.Text = "Uploading Your Forms";
            await UploadForms("");
        }

        private static async Task UploadForms(string FormID)
        {
            try
            {
                List<DBFormInstance> slFormsToUpload = new List<DBFormInstance>();

                if (!string.IsNullOrEmpty(FormID))
                {
                    DBFormInstance form = await App.DB.GetForm(FormID);
                    slFormsToUpload.Add(form);
                }
                else
                {
                    List<DBFormInstance> slForms = await App.DB.GetForms(true);
                    List<DBFormInstance> slDeleted = slForms.Where(x =>
                                    (x.Status == fldFormCapCommon.FORM_STATUS_USERDELETED)
                                    && (x.LastUploaded > DateTime.MinValue)
                                ).ToList();
                    List<DBFormInstance> slModified = slForms.Where(x =>
                                    (x.OwnedBy == Settings.ClearUsername)
                                    && !(fldFormCapCommon.FORM_STATUS_NEW + fldFormCapCommon.FORM_STATUS_ADMINDELETED + fldFormCapCommon.FORM_STATUS_IMPORTED + fldFormCapCommon.FORM_STATUS_COMPLETED).Contains(x.Status)
                                    && (x.LastUploaded < x.ModifiedDate)
                                ).ToList();

                    foreach (DBFormInstance form in slDeleted)
                        slFormsToUpload.Add(form);
                    foreach (DBFormInstance form in slModified)
                        slFormsToUpload.Add(form);
                }

                foreach (DBFormInstance uploadForm in slFormsToUpload)
                {
                    await UploadAttachments(uploadForm);
                    await UploadSignatures(uploadForm);
                    AddHeadersToKVPs(uploadForm);
                    if (!string.IsNullOrEmpty(uploadForm.SignedDocData))
                    {
                        if (await UploadFormWithPDF(uploadForm))
                        {
                            if (fldFormCapCommon.Org_Attachment_Forms.Contains(uploadForm.FormType))
                            {
                                await AddDocToOrg(uploadForm);
                            }
                        }
                    }
                    else if (await UploadForm(uploadForm, string.Empty))
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static async Task AddDocToOrg(DBFormInstance form)
        {
            //
        }

        private static void AddHeadersToKVPs(DBFormInstance form)
        {
            string sPrefix = "FCINSTANCE__";
            int AttachNumber = 1;
            foreach (DBFormInstanceAttachment attach in form.Attachments)
            {
                DBFormField field;
                string sKey = $"{sPrefix}ATTACHFILEGUID{AttachNumber}";
                if (form.Fields.ContainsKey(sKey))
                    field = form.Fields[sKey];
                else
                {
                    field = new DBFormField();
                    field.FieldName = sKey;
                    form.Fields.Add(field.FieldName, field);
                }
                field.FieldValue = attach.FileGUID;
                if (field.FieldValue == null)
                    field.FieldValue = string.Empty;
                field.FieldType = "C";

                sKey = $"{sPrefix}ATTACHFILENAME{AttachNumber}";
                if (form.Fields.ContainsKey(sKey))
                    field = form.Fields[sKey];
                else
                {
                    field = new DBFormField();
                    field.FieldName = sKey;
                    form.Fields.Add(field.FieldName, field);
                }
                field.FieldValue = attach.FileName;
                if (field.FieldValue == null)
                    field.FieldValue = string.Empty;
                field.FieldType = "C";

                sKey = $"{sPrefix}ATTACHNAME{AttachNumber}";
                if (form.Fields.ContainsKey(sKey))
                    field = form.Fields[sKey];
                else
                {
                    field = new DBFormField();
                    field.FieldName = sKey;
                    form.Fields.Add(field.FieldName, field);
                }
                field.FieldValue = attach.Name;
                if (field.FieldValue == null)
                    field.FieldValue = string.Empty;
                field.FieldType = "C";

                AttachNumber++;
            }

            //signatures as fields
            foreach (RequiredSignature sig in Enum.GetValues(typeof(RequiredSignature)))
            {
                string GUID = form.GetSignatureFileGUID(sig);

                DBFormField field;
                int nKey = (int)sig;
                if (Enum.IsDefined(typeof(RequiredSignature), nKey))
                {
                    string sKey = sPrefix + ((RequiredSignatureBookMark)nKey).ToString() + "GUID";
                    if (form.Fields.ContainsKey(sKey))
                        field = form.Fields[sKey];
                    else
                    {
                        field = new DBFormField();
                        field.FieldName = sKey;
                        form.Fields.Add(field.FieldName, field);
                    }
                    field.FieldValue = GUID;
                    field.FieldType = "C";
                }
            }
        }

        private static async Task UploadAttachments(DBFormInstance form)
        {
            try
            {
                IFolder storage = FileSystem.Current.LocalStorage;
                foreach (DBFormInstanceAttachment oAttach in form.Attachments)
                {
                    if (!string.IsNullOrEmpty(oAttach.FileName) && string.IsNullOrEmpty(oAttach.FileGUID))
                    {
                        string sFileToUpload = PortablePath.Combine(storage.Path, SyncHelper.FormsFolder, oAttach.FormInstanceID, oAttach.FileName);
                        //ToDo: Zip up the file. We are using FastZip by SharpZipLib from Nuget.

                        //ToDo: populate memory stream from file

                        string FolderName = PortablePath.Combine(SyncHelper.FormsFolder, oAttach.FormInstanceID);
                        IFolder localStorage = await ForceDirectory(FolderName);

                        IFile attachFile = await localStorage.GetFileAsync(sFileToUpload);
                        Stream ms = await attachFile.OpenAsync(PCLStorage.FileAccess.Read);

                        GenericResponse<string> resUpload = await App.soapService.UploadAttachment(attachFile.Name, ms);
                        oAttach.FileGUID = resUpload.Data;
                        await App.DB.AsyncDb.UpdateAsync(oAttach);
                    }
                }
            }
            catch (Exception ex)
            {
                //Xamarin.Insights.Report(ex, "Process", "UploadAttachments", Xamarin.Insights.Severity.Error);
                throw;
            }
        }

        private static async Task<bool> UploadForm(DBFormInstance form, string FileGUID)
        {
            if (Settings.DebugOptions.ProcessSync(Settings.DebugOptions.UploadForms))
            {
                GenericResponse<bool> resUpload = await App.soapService.UploadForm(form, FileGUID);

                if (resUpload.Data)
                {
                    form.LastUploaded = DateTime.Now;
                    form.LastUploadStatus = form.Status;
                    await App.DB.AsyncDb.UpdateAsync(form);

                }
                return resUpload.Data;
            }
            else
            {
                return false;
            }
        }

        private static async Task<bool> UploadFormWithPDF(DBFormInstance form)
        {
            //ToDo: Zip up the file. We are using FastZip by SharpZipLib from Nuget.
            IFile signedDoc = await FileSystem.Current.GetFileFromPathAsync(form.SignedDocData);
            //ToDo: populate memory stream from file
            Stream oFile = await signedDoc.OpenAsync(PCLStorage.FileAccess.Read);
            GenericResponse<string> resUpload = await App.soapService.UploadAttachment(signedDoc.Name, oFile);
            string fileGUID = resUpload.Data;
            await UploadForm(form, fileGUID);
            form.LastUploaded = DateTime.Now;
            form.LastUploadStatus = form.Status;
            await App.DB.AsyncDb.UpdateAsync(form);

            return true;
        }

        private static async Task UploadSignatures(DBFormInstance form)
        {
            try
            {
                IFolder storage = FileSystem.Current.LocalStorage;
                bool bSignaturesUploaded = false;
                foreach (RequiredSignature sig in Enum.GetValues(typeof(RequiredSignature)))
                {
                    string GUID = form.GetSignatureFileGUID(sig);
                    string FilePath = form.GetSignaturePath(sig);

                    if (!string.IsNullOrEmpty(FilePath) && string.IsNullOrEmpty(GUID))
                    {
                        string sFileToUpload = FilePath;// PortablePath.Combine(storage.Path, SyncHelper.SignaturesFolder, oAttach.FormInstanceID, oAttach.FileName);
                        //upload signature
                        IFile attachFile = await storage.GetFileAsync(sFileToUpload);
                        Stream ms = await attachFile.OpenAsync(PCLStorage.FileAccess.Read);

                        GenericResponse<string> resUpload = await App.soapService.UploadAttachment(attachFile.Name, ms);

                        form.SetSignatureFileGUID(sig, resUpload.Data);
                        bSignaturesUploaded = true;
                    }
                }

                if (bSignaturesUploaded)
                    await App.DB.AsyncDb.UpdateAsync(form);

            }
            catch (Exception ex)
            {
                //Xamarin.Insights.Report(ex, "Process", "UploadSignatures", Xamarin.Insights.Severity.Error);
                throw;
            }

        }

        private static async Task ClearUnwantedForms(Label lblProgress)
        {
            if (Settings.DebugOptions.ProcessSync(Settings.DebugOptions.ClearUnwantedForms))
            {
                lblProgress.Text = "Clearing Unwanted Forms";

                List<DBFormInstance> slFormsToDelete = await App.DB.AsyncDb.Table<DBFormInstance>().Where(
                        form => (form.OwnedBy != Settings.ClearUsername)
                                || (form.Status == fldFormCapCommon.FORM_STATUS_ADMINDELETED)
                                || ((form.LastUploaded == DateTime.MinValue)
                                     && (form.Status == fldFormCapCommon.FORM_STATUS_USERDELETED)
                                    )
                                || (form.LastUploadStatus == fldFormCapCommon.FORM_STATUS_USERDELETED)
                                || ((form.LastUploadStatus == form.Status)
                                        && (form.Status == fldFormCapCommon.FORM_STATUS_SUBMITTED)
                                    )
                    ).ToListAsync();

                foreach (DBFormInstance form in slFormsToDelete)
                {
                    await App.DB.DeleteForm(form.FormInstanceID);
                }
            }
        }

        private static async Task DownloadUserReviews(Label lblProgress)
        {
            if (Settings.DebugOptions.ProcessSync(Settings.DebugOptions.DownloadUserReviews))
            {
                lblProgress.Text = "Downloading User Reviews";
                //todo: Implement DownloadUserReviews
            }

        }

        private static async Task UpdateFormOwnership(Label lblProgress)
        {
            if (Settings.DebugOptions.ProcessSync(Settings.DebugOptions.UpdateFormOwnership))
            {
                lblProgress.Text = "Updating form Ownership";
                List<DBFormInstance> formsToCheck = await App.DB.GetForms(false);
                formsToCheck = formsToCheck.Where(x => x.OwnedBy == Settings.ClearUsername && x.Status != fldFormCapCommon.FORM_STATUS_USERDELETED && x.Status != fldFormCapCommon.FORM_STATUS_NEW).ToList();
                foreach (DBFormInstance dbForm in formsToCheck)
                {
                    GenericResponse<DBFormInstance> resForm = await App.soapService.GetFormHeaderFromServer(dbForm.FormInstanceID);
                    if (resForm.Data != null)
                    {
                        if (dbForm.OwnedBy != resForm.Data.OwnedBy)
                        {
                            dbForm.OwnedBy = resForm.Data.OwnedBy;
                            await App.DB.AsyncDb.UpdateAsync(dbForm);
                        }
                        else if ((dbForm.ModifiedDate <= resForm.Data.ModifiedDate)
                            && (dbForm.Status == fldFormCapCommon.FORM_STATUS_SUBMITTED)
                            && (resForm.Data.Status == fldFormCapCommon.FORM_STATUS_REJECTED))
                        {
                            dbForm.Status = fldFormCapCommon.FORM_STATUS_USERDELETED;
                            await App.DB.AsyncDb.UpdateAsync(dbForm);
                        }
                    }
                }
            }
        }

        private static async Task GetStaticBaseData(Label lblProgress)
        {
            DateTime dShouldSync = DateTime.Now.AddMinutes(-30);
            if (Settings.LastBaseDataSync < dShouldSync)
            {
                lblProgress.Text = "Fetching Settings";
                await SyncSettings();

                await SyncPlans(lblProgress);

                await SyncSites(lblProgress);

                await SyncOfficers(lblProgress);

                await SyncPickLists(lblProgress);

                await GetCustomForms(lblProgress);

                Settings.LastBaseDataSync = DateTime.Now;
            }
        }

        private static async Task GetCustomForms(Label lblProgress)
        {
            if (Settings.DebugOptions.ProcessSync(Settings.DebugOptions.GetCustomForms))
            {
                lblProgress.Text = "Fetching Custom Forms";
                GenericResponse<List<DBCustomForm>> customForms = await App.soapService.GetCustomForms();
                if (customForms.Data != null)
                {
                    lblProgress.Text = "Saving Custom Forms";
                    await App.DB.AsyncDb.RunInTransactionAsync((SQLiteConnection connection) =>
                    {
                        connection.DeleteAll<DBCustomForm>();
                        connection.DeleteAll<DBCustomFormQuestion>();
                        foreach (DBCustomForm wsForm in customForms.Data)
                        {
                            connection.Insert(wsForm);
                            foreach (DBCustomFormQuestion question in wsForm.Questions)
                            {
                                connection.Insert(question);
                            }
                        }
                    });

                    foreach (DBCustomForm wsForm in customForms.Data)
                    {
                        if (!string.IsNullOrEmpty(wsForm.TemplateFileID))
                        {
                            string folder = PortablePath.Combine(TemplateFolder, wsForm.FormID);
                            await DownloadFile(wsForm.TemplateFileID, wsForm.TemplateFileID.Trim() + ".DOCX", folder);
                        }
                    }
                }
            }
        }

        private static async Task SyncSites(Label lblProgress)
        {
            if (Settings.DebugOptions.ProcessSync(Settings.DebugOptions.SyncSites))
            {
                lblProgress.Text = "Fetching Sites";

                GenericResponse<List<DBSite>> sites = await App.soapService.GetSites();

                lblProgress.Text = "Saving Sites";

                await App.DB.AsyncDb.RunInTransactionAsync((SQLiteConnection connection) =>
                {
                    connection.DeleteAll<DBSite>();
                    foreach (DBSite site in sites.Data)
                    {
                        connection.Insert(site);
                    }
                });
            }
        }

        private static async Task SyncOfficers(Label lblProgress)
        {
            if (Settings.DebugOptions.ProcessSync(Settings.DebugOptions.SyncOfficers))
            {
                lblProgress.Text = "Fetching Officers";

                GenericResponse<List<DBOfficer>> officers = await App.soapService.GetOfficers();

                lblProgress.Text = "Saving Officers";

                await App.DB.AsyncDb.RunInTransactionAsync((SQLiteConnection connection) =>
                {
                    connection.DeleteAll<DBOfficer>();
                    foreach (DBOfficer item in officers.Data)
                    {
                        connection.Insert(item);
                    }
                });
            }
        }

        private static async Task SyncPickLists(Label lblProgress)
        {
            if (Settings.DebugOptions.ProcessSync(Settings.DebugOptions.SyncPickLists))
            {
                lblProgress.Text = "Fetching Pick Lists";

                GenericResponse<List<DBPickItem>> pickLists = await App.soapService.GetAllPickItems();

                lblProgress.Text = "Saving Pick Lists";

                await App.DB.AsyncDb.RunInTransactionAsync((SQLiteConnection connection) =>
                {
                    connection.DeleteAll<DBPickItem>();
                    foreach (DBPickItem item in pickLists.Data)
                    {
                        connection.Insert(item);
                    }
                });
            }
        }

        private static async Task SyncPlans(Label lblProgress)
        {
            if (Settings.DebugOptions.ProcessSync(Settings.DebugOptions.SyncPlans))
            {
                lblProgress.Text = "Fetching Plans";

                GenericResponse<List<DBQualPlan>> plans = await App.soapService.GetPlans();

                lblProgress.Text = "Saving Plans";

                await App.DB.AsyncDb.RunInTransactionAsync((SQLiteConnection connection) =>
                {
                    connection.DeleteAll<DBQualPlan>();
                    connection.DeleteAll<DBQualPlanDet>();
                    foreach (DBQualPlan form in plans.Data)
                    {
                        connection.Insert(form);
                        foreach (DBQualPlanDet field in form.Qualifications)
                        {
                            connection.Insert(field);
                        }
                    }
                });
            }
        }

        private static async Task SyncSettings()
        {
            if (Settings.DebugOptions.ProcessSync(Settings.DebugOptions.SyncSettings))
            {
                await SaveConfigBool(oPICSConfig.cfgKey_FCA_Debug_Mode, false);
                await SaveConfigBool(oPICSConfig.cfgKey_FCA_DeleteForms, true);
                await SaveConfigBool(oPICSConfig.cfgKey_FCA_Apps_Enabled, false);
                await SaveConfigBool(oPICSConfig.cfgKey_FCA_Apps_Filter_RecrOff, true);
                await SaveConfigString(oPICSConfig.cfgKey_FCA_Apps_Filter_Status, string.Empty);

                await SaveConfigBool(oPICSConfig.cfgKey_FCA_Learners_Enabled, false);
                await SaveConfigBool(oPICSConfig.cfgKey_FCA_Learners_Filter_MainOff, true);
                await SaveConfigString(oPICSConfig.cfgKey_FCA_SendEvApp_Ready_ApStatus, string.Empty);
                await SaveConfigString(oPICSConfig.cfgKey_FCA_SendEvApp_Ready_ApSubStatus, string.Empty);

                await SaveConfigInt(oPICSConfig.cfgKey_FCA_ReviewsDaysFwd, 14);
                await SaveConfigInt(oPICSConfig.cfgKey_FCA_ReviewsDaysBack, 7);

                Settings.Orgs_AllowCreate = await DownloadConfigBool(oPICSConfig.cfgKey_FCA_Orgs_AllowCreate, true);
                Settings.Orgs_StatusForNew = await DownloadConfigString(oPICSConfig.cfgKey_FCA_Orgs_StatusForNew, fldOrgs.CStatusLive);

                foreach (string s in oPICSConfig.ReviewDefaultFormConfigList)
                {
                    await SaveConfigString(s, string.Empty);
                }
            }
            Settings.DebugOptions.Refresh();
        }


        private static async Task<string> DownloadConfigString(string key, string _default)
        {
            GenericResponse<string> res = await App.soapService.GetConfig(oPICSConfig.FCA_Section, key);
            return string.IsNullOrEmpty(res.Data) ? _default : res.Data;
        }

        private static async Task<bool> DownloadConfigBool(string key, bool _default)
        {
            GenericResponse<string> res = await App.soapService.GetConfig(oPICSConfig.FCA_Section, key);
            return string.IsNullOrEmpty(res.Data) ? _default : res.Data.Equals("T");
        }

        private static async Task<int> DownloadConfigInt(string key, int _default)
        {
            GenericResponse<string> res = await App.soapService.GetConfig(oPICSConfig.FCA_Section, key);
            int value;
            if (!int.TryParse(res.Data, out value))
            {
                value = _default;
            }
            return value;
        }

        private static async Task SaveConfigString(string Key, string _default)
        {
            Settings.SetString(Key, await DownloadConfigString(Key, _default));
        }

        private static async Task SaveConfigBool(string Key, bool _default)
        {
            Settings.SetBool(Key, await DownloadConfigBool(Key, _default));
        }

        private static async Task SaveConfigInt(string Key, int _default)
        {
            Settings.SetInt(Key, await DownloadConfigInt(Key, _default));
        }

        private static async Task SyncOrgs(bool NewOnly, Label lblProgress)
        {
            if (Settings.DebugOptions.ProcessSync(Settings.DebugOptions.SyncOrgs))
            {
                lblProgress.Text = "Adding New Organisations";
                await AddOrgs(lblProgress);
                if (!NewOnly)
                {
                    lblProgress.Text = "Updating Modified Organisations";
                    await UpdateOrgs(lblProgress);
                    //TODO: Implement CreateUsedOrgsList.
                }
            }
        }
        private static async Task AddOrgs(Label lblProgress)
        {
            List<DBOrganisation> newOrgs = await App.DB.GetOrgsBySyncStatus(fldFormCapCommon.FCA_Org_Status_New);
            foreach (DBOrganisation org in newOrgs)
            {
                try
                {
                    GenericResponse<string> resOrg = await App.soapService.AddOrg(org);
                    if (!string.IsNullOrEmpty(resOrg.Data))
                    {
                        org.SyncStatus = fldFormCapCommon.FCA_Org_Status_Unmodified;
                        org.Place = resOrg.Data;
                        await App.DB.AsyncDb.UpdateAsync(org);
                    }
                }
                catch (Exception ex)
                {
                    lblProgress.Text = "Error: AddOrgs Org \"" + org.Name + "\":\n" + ex.Message;
                    throw;
                }
            }
        }

        private static async Task UpdateOrgs(Label lblProgress)
        {
            List<DBOrganisation> newOrgs = await App.DB.GetOrgsBySyncStatus(fldFormCapCommon.FCA_Org_Status_Modified);
            foreach (DBOrganisation org in newOrgs)
            {
                try
                {
                    await App.soapService.UpdateOrg(org);
                    org.SyncStatus = fldFormCapCommon.FCA_Org_Status_Unmodified;
                    await App.DB.AsyncDb.UpdateAsync(org);
                }
                catch (Exception ex)
                {
                    lblProgress.Text = "Error: UpdateOrgs Org \"" + org.Name + "\":\n" + ex.Message;
                    throw;
                }
            }
        }

        public static async Task<bool> CheckForWifiOnly()
        {
            if (Settings.WifiOnly && !CrossConnectivity.Current.ConnectionTypes.Contains(Plugin.Connectivity.Abstractions.ConnectionType.WiFi))
            {
                await App.Current.MainPage.DisplayError("You are not connected to a WiFi network. Process aborted.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
