using FCA.Imp;
using FCA.Interfaces;
using FCA.Models;
using FCA.Shared;
using FCA.UWP.PICSWS;
using Pellcomp.Vs.Mobile.FormCaptureApp.lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamTest.Helpers;

[assembly: Dependency(typeof(SoapService))]
namespace FCA.Imp
{
    public class SoapService : ISoapService
    {
        private const int MAX_LEARNER_DOWNLOAD = 10;
        IPICSWebService webService;
        string authToken = string.Empty;

        public SoapService()
        {
            webService = new PICSWebServiceClient(new BasicHttpBinding(), new EndpointAddress(Settings.WebServiceURL));
        }

        private void HandleCommonResponse(PublicPICSResponse response)
        {
            if (!string.IsNullOrEmpty(response.NewAuthToken)) //new auth token has been generated. 
                authToken = response.NewAuthToken;
            if (response.ResponseStatus == 8)
                App.Current.HadAuthenticationError = true;
        }

        private T NewRequest<T>() where T : PublicPICSRequest, new()
        {
            T result = new T();
            result.Username = "ian@valhalla.local";
            result.Password = "1q2w3e4R";
            result.AuthToken = authToken;
            return result;
        }

        private GenericResponse<T> SingleResponse<T>()
        {
            return new GenericResponse<T>();
        }

        private GenericResponse<List<T>> ListResponse<T>()
        {
            return new GenericResponse<List<T>>();
        }

        public async Task<string> TestWS(string test)
        {
            return await Task.Run(() =>
            {
                return webService.SimpleServiceTest(test);
            });
        }

        public async Task<GenericResponse<bool>> AuthenticateUser(string URL, string username, string Password)
        {
            return await Task.Run(() =>
            {
                try
                {
                    GenericResponse<bool> result = SingleResponse<bool>();
                    Settings.WebServiceURL = URL;
                    AuthenticateUserRequest req = new AuthenticateUserRequest();
                    req.Username = "WS_FORMC";
                    req.Password = "5D87C1CADCA74ACAB9C0";

                    req.PICSUsername = username;
                    req.PICSPassword = Password;
                    AuthenticateUserResponse res = webService.AuthenticateUser(req);

                    result.Data = res.LoginStatus;
                    if (res.LoginStatus)
                    {
                        Settings.AuthToken = res.AuthToken;
                        Settings.UserName = username;
                        Settings.Password = Password;

                        GetUserDetailsRequest reqUser = NewRequest<GetUserDetailsRequest>();
                        reqUser.PICSUsername = req.PICSUsername;
                        GetUserDetailsResponse resUser = webService.GetUserDetails(reqUser);

                        if (resUser.ResponseStatus != 0)
                            throw new Exception(res.ResponseText);

                        Settings.ClearUsername = resUser.PICSUserCode;
                        Settings.FullName = resUser.DisplayName;
                        Settings.LoggedIn = resUser.CanUseFormCap;
                        if (resUser.LinkType == "O")
                            Settings.OfficerCode = resUser.LinkCode;
                        else
                            Settings.OfficerCode = "";
                        // User's visible site codes
                        Settings.UserSites = string.Join("*", resUser.UserSites);
                    }
                    else
                    {
                        if (res.ErrorDetails != null)
                        {
                            if (!string.IsNullOrEmpty(res.ErrorDetails.FurtherDetails))
                                result.ResponseText = res.ErrorDetails.FurtherDetails;
                            else
                                result.ResponseText = res.ErrorDetails.ErrorDescription;
                        }
                        else
                        {
                            result.ResponseText = "Invalid Credentials";
                        }
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    var v = ex.Message;
                    throw;
                }
            });
        }

        public async Task<GenericResponse<string>> GetConfig(string Section, string Key)
        {
            return await Task.Run(() =>
            {
                try
                {
                    GenericResponse<string> result = SingleResponse<string>();

                    GetConfigSystemSettingRequest req = NewRequest<GetConfigSystemSettingRequest>();
                    req.ConfigSection = Section;
                    req.ConfigKey = Key;
                    //Debug.WriteLine("Cookie Count: " + webService.CookieContainer.Count);
                    GetConfigSystemSettingResponse res = webService.GetConfigSystemSetting(req);
                    HandleCommonResponse(res);


                    if (res.ResponseStatus != 0) //Not sucess
                    {
                        throw new Exception(res.ResponseText);
                    }
                    result.Data = res.ConfigSetting.ConfigValue;

                    return result;
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public async Task<GenericResponse<Dictionary<string, string>>> GetSystemInfo(bool fullDetails = false)
        {
            return await Task.Run(() =>
            {
                try
                {
                    GenericResponse<Dictionary<string, string>> result = SingleResponse<Dictionary<string, string>>();
                    result.Data = new Dictionary<string, string>();

                    GetSystemInfoRequest req = NewRequest<GetSystemInfoRequest>();
                    req.FullDetails = fullDetails;

                    GetSystemInfoResponse res = webService.GetSystemInfo(req);
                    HandleCommonResponse(res);
                    if (res.ResponseStatus != 0) //Not sucess
                    {
                        throw new Exception(res.ResponseText);
                    }
                    foreach (SystemInfoLine infoLine in res.SystemInfoList)
                    {
                        result.Data.Add(infoLine.Name, infoLine.Value);
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    //Xamarin.Insights.Report(ex, "Process", "GetSystemInfo",//Xamarin.Insights.Severity.Error);
                    //Debug.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public async Task<GenericResponse<List<PicklistItem>>> GetPickList(PicklistType Type)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = ListResponse<PicklistItem>();
                    GetPicklistRequest req = NewRequest<GetPicklistRequest>();
                    req.PicklistType = Type;
                    //req.PicklistTypeSpecified = true;   //This must be set to actually send the picklistType enum.
                    GetPicklistResponse res = webService.GetPicklist(req);
                    HandleCommonResponse(res);
                    if (res.PickList != null)
                    {
                        if (res.PickList.Items.Length > 0)
                        {
                            result.Data = res.PickList.Items.ToList();
                        }
                    }
                    else
                    {
                        if (res.ErrorDetails != null)
                        {
                            if (!string.IsNullOrEmpty(res.ErrorDetails.FurtherDetails))
                                result.ResponseText = res.ErrorDetails.FurtherDetails;
                            else
                                result.ResponseText = res.ErrorDetails.ErrorDescription;
                        }
                    }
                    if (result.Data == null)
                        result.Data = new List<PicklistItem>();
                    return result;
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public async Task<GenericResponse<List<DBPickItem>>> GetAllPickItems()
        {
            var result = ListResponse<DBPickItem>();

            List<PicklistType> pickTypes = new List<PicklistType>();
            pickTypes.Add(PicklistType.ptLearnerChangeReqType);
            pickTypes.Add(PicklistType.ptLearnerUserEndCode);
            pickTypes.Add(PicklistType.ptLearnerUserDestinationCode);

            result.Data = new List<DBPickItem>();
            foreach (PicklistType type in pickTypes)
            {
                var pick = await GetPickList(type);
                if (pick.Data != null)
                {
                    if (pick.Data.Count > 0)
                    {
                        foreach (PicklistItem oInst in pick.Data)
                        {
                            DBPickItem dbPick = new DBPickItem();
                            dbPick.PickType = type.ToString();
                            dbPick.Key = oInst.Code;
                            dbPick.Index = dbPick.PickType + "_" + dbPick.Key;
                            dbPick.Description = oInst.Description;
                            result.Data.Add(dbPick);
                        }
                    }
                    else
                    {
                        //No Items found
                    }
                }
            }


            return result;
        }
        
        public async Task<GenericResponse<List<DBApplicant>>> FindApplicants(FindApplicantsSoapRequest findApplicants)
        {
            try
            {

                SearchForApplicantsRequest req = NewRequest<SearchForApplicantsRequest>();
                GenericResponse<List<DBApplicant>> result = null;
                req.PageSize = 10;
                req.PageNumber = 1;
                req.Surname = findApplicants.Surname;
                req.Firstname = findApplicants.Forenames;
                req.Postcode = findApplicants.Postcode;
                req.RecruitmentOfficer = findApplicants.RecruitmentOfficer;
                req.Site = findApplicants.Sites;
                req.Status = fldOrgs.CStatusLive;

                SearchForApplicantsResponse res = webService.SearchForApplicantsAsync(req).Result;
                HandleCommonResponse(res);

                // Error on failed response, but allow ErrorCode=2 (not found)
                if ((res.ResponseStatus != 0) && (res.ErrorDetails != null) && (res.ErrorDetails.ErrorCode != 2)) //Not success
                {
                    throw new Exception(res.ResponseText);
                }

                result = ListResponse<DBApplicant>();
                result.Data = new List<DBApplicant>();
                if (res.Applicants != null)
                {
                    for (int i = 0; i < res.Applicants.Count(); i++)
                    {
                        // Only add live applicants (not deleted or ~)
                        if (res.Applicants[i].SysStatus.Equals("L"))
                            result.Data.Add(ApplicantToDBApplicant(res.Applicants[i]));
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                //Xamarin.Insights.Report(ex, "Process", "FindApplicants",//Xamarin.Insights.Severity.Error);
                //Debug.WriteLine(ex.Message);
                return null;
            }
        }

        private DBApplicant ApplicantToDBApplicant(Applicant applicant)
        {
            DBApplicant Result = new DBApplicant
            {
                RecGUID = applicant.RecGUID,
                ApIdent = applicant.ApIdent,
                Surname = applicant.Surname,
                Forenames = applicant.Forenames,
                DOB = applicant.DOB,
                Sex = applicant.Sex,
                NINumber = applicant.NationalInsuranceNumber,
                PostCode = applicant._address?.PostCode,
                Status = applicant.Status,
                SubStatus = applicant.SubStatus,
                Employer = applicant.Employer,
                Site = applicant.Site,
                QualPlan = applicant.QualPlan,
                ULN = applicant.ULN,
                RecruitmentOfficer = applicant.RecruitmentOfficer,
                Downloaded = DateTime.Now,
                LastUsed = DateTime.Now
            };
            if (!String.IsNullOrEmpty(Result.Employer))
            {
                Result.EmployerName = GetSingleOrganisationByPlace(applicant.Employer).Result.Data?.Name;
            }
            return Result;
        }

        public async Task<GenericResponse<List<DBLearner>>> FindLearners(FindLearnersSoapRequest request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    SearchForLearnersRequest req = NewRequest<SearchForLearnersRequest>();
                    GenericResponse<List<DBLearner>> result = null;
                    req.PageSize = 50;
                    req.PageNumber = 1;
                    req.Surname = request.Surname;
                    req.Firstname = request.Forename;
                    req.Postcode = request.Postcode;
                    req.MainOfficerCode = request.MainOfficer;
                    req.Site = request.Sites;
                    SearchForLearnersResponse res = webService.SearchForLearners(req);
                    HandleCommonResponse(res);

                    // Error on failed response, but allow ErrorCode=2 (not found)
                    if ((res.ResponseStatus != 0) && (res.ErrorDetails != null) && (res.ErrorDetails.ErrorCode != 2)) //Not success
                    {
                        throw new Exception(res.ResponseText);
                    }

                    result = ListResponse<DBLearner>();
                    result.Data = new List<DBLearner>();
                    if (res.Learners != null)
                    {
                        for (int i = 0; (i < res.Learners.Count()) && (i < MAX_LEARNER_DOWNLOAD); i++)
                        {
                            // Only add live learners (not deleted or ~)
                            if (LearnerIsLive(res.Learners[i].SysStatus))
                                result.Data.Add(LearnerToDBLearner(res.Learners[i]));
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                   //Xamarin.Insights.Report(ex, "Process", "FindLearners",//Xamarin.Insights.Severity.Error);
                   //Debug.writeLine(ex.Message);
                    return null;
                }
            });
        }

        private bool LearnerIsLive(string learnerSysStatus)
        {
            return (!(fldClient.TRAINEE_STATUS_DELETED + fldClient.TRAINEE_STATUS_PARTIALENTRY + fldClient.TRAINEE_STATUS_ARCHIVED).Contains(learnerSysStatus));
        }

        private DBLearner LearnerToDBLearner(Learner learner)
        {
            DBLearner Result = new DBLearner
            {
                Ident = learner.Ident,
                Surname = learner.Surname,
                Firstname = learner.Forename,
                DOB = learner.DateOfBirth,
                Sex = learner.Sex,
                NINumber = learner.NationalInsuranceNumber,
                Phone = learner.Phone,
                MobilePhone = learner.Mobile,
                Email = learner.Email,
                ULIN = learner.ULIN,
                ULN = learner.ULN,
                TrainingStart = learner.TrainingStart,
                TrainingExpEnd = learner.TrainingExpEnd,
                TrainingEnd = learner.TrainingEnd,
                Downloaded = DateTime.Now
            };
            if (learner.Address != null)
            {
                Result.Address1 = learner.Address.Address1;
                Result.Address2 = learner.Address.Address2;
                Result.Address3 = learner.Address.Address3;
                Result.Address4 = learner.Address.Address4;
                Result.Postcode = learner.Address.PostCode;
            }
            if (learner.CurrentPlacement != null)
            {
                Result.EmployerCode = learner.CurrentPlacement.Place;
                Result.EmployerName = learner.CurrentPlacement.Name;
            }
            return Result;
        }

        public async Task<GenericResponse<List<DBQualPlan>>> GetPlans()
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = ListResponse<DBQualPlan>();

                    GetQualificationPlansRequest req = NewRequest<GetQualificationPlansRequest>();
                    req.IncludeQuals = true;
                    //req.IncludeQualsSpecified = true;

                    req.IncludeSites = true;
                    //req.IncludeSitesSpecified = true;

                    GetQualificationPlansResponse res = webService.GetQualificationPlans(req);
                    HandleCommonResponse(res);
                    result.Data = new List<DBQualPlan>();
                    if (res.QualificationPlans != null)
                    {
                        if (res.QualificationPlans.Length > 0)
                        {
                            foreach (QualificationPlan oInst in res.QualificationPlans)
                            {
                                DBQualPlan dbPlan = new DBQualPlan();

                                dbPlan.RecGUID = oInst.RecGUID;
                                dbPlan.PlanCode = oInst.PlanCode;
                                dbPlan.Title = oInst.Title;
                                dbPlan.FrameworkTitle = oInst.FrameworkTitle;
                                dbPlan.FrameworkCode = oInst.FrameworkCode;
                                dbPlan.FrameworkPathway = oInst.FrameworkPathway;
                                if (oInst.Sites != null)
                                    dbPlan.Sites = String.Join(";", oInst.Sites);

                                if (oInst.Qualifications != null)
                                {
                                    foreach (QualificationPlanQual oQual in oInst.Qualifications)
                                    {
                                        DBQualPlanDet dbPlanDet = new DBQualPlanDet();
                                        dbPlanDet.RecGUID = oQual.RecGUID;
                                        dbPlanDet.PlanCode = dbPlan.PlanCode;
                                        dbPlanDet.QualType = oQual.QualType;
                                        dbPlanDet.QualCode = oQual.QualCode;
                                        dbPlanDet.Title = oQual.QualTitle;
                                        dbPlanDet.AwardingBody = oQual.QualAwardingBody;
                                        dbPlanDet.Level = oQual.QualLevelV2;
                                        dbPlanDet.StartUnit = oQual.StartUnit;
                                        dbPlanDet.StartTime = oQual.StartTime;
                                        dbPlanDet.AchievementUnit = oQual.AchievementUnit;
                                        dbPlanDet.AchievementTime = oQual.AchievementTime;
                                        dbPlan.Qualifications.Add(dbPlanDet);
                                    }
                                }

                                result.Data.Add(dbPlan);
                            }
                        }
                        else
                        {
                            //No Plans found
                        }
                    }
                    else
                    {
                        if (res.ErrorDetails != null)
                        {
                            if (!string.IsNullOrEmpty(res.ErrorDetails.FurtherDetails))
                                result.ResponseText = res.ErrorDetails.FurtherDetails;
                            else
                                result.ResponseText = res.ErrorDetails.ErrorDescription;
                        }
                    }

                    return result;
                }
                catch (Exception ex)
                {
                   //Debug.writeLine(ex.Message);
                    throw;
                }
            });
        }

        public async Task<GenericResponse<Dictionary<string, string>>> GetFileData(string FileGUID)
        {
            return await Task.Run(() =>
            {
                try
                {
                    GenericResponse<Dictionary<string, string>> result = SingleResponse<Dictionary<string, string>>();
                    result.Data = new Dictionary<string, string>();

                    GetAttachedFileDetailsRequest req = NewRequest<GetAttachedFileDetailsRequest>();
                    req.FileGUID = FileGUID;

                    GetAttachedFileDetailsResponse res = webService.GetAttachedFileDetails(req);

                    HandleCommonResponse(res);

                    if (res.ResponseStatus != 0)
                    {
                        throw new Exception(res.ResponseText);
                    }

                    result.Data.Add("FileGUID", res.FileGUID);
                    result.Data.Add("FileName", res.FileName);
                    return result;
                }
                catch (Exception ex)
                {
                   //Xamarin.Insights.Report(ex, "Process", "GetFileData",//Xamarin.Insights.Severity.Error);
                   //Debug.writeLine(ex.Message);
                    throw;
                }
            });
        }

        public async Task<GenericResponse<DBFormInstance>> GetFormHeaderFromServer(string FormID)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = SingleResponse<DBFormInstance>();

                    GetFormListRequest req = NewRequest<GetFormListRequest>();
                    req.OwnerUsername = Settings.ClearUsername;
                    req.RequiredStatuses = fldFormCapCommon.FORMS_TO_DOWNLOAD_TO_TABLET;

                    GetFormListResponse res = webService.GetFormList(req);
                    HandleCommonResponse(res);

                    GetFormRequest reqForm = NewRequest<GetFormRequest>();
                    reqForm.FormInstanceID = FormID;
                    GetFormResponse resForm = webService.GetForm(reqForm);
                    if (resForm.FormInstance != null)
                    {
                        FormInstance wsInst = resForm.FormInstance;
                        result.Data = new DBFormInstance();
                        result.Data.FormInstanceID = wsInst.FormInstanceID;
                        result.Data.Title = wsInst.Title;
                        result.Data.Status = wsInst.Status;
                        result.Data.FormType = wsInst.FormType;
                        result.Data.CreatedDate = wsInst.CreatedDate;
                        result.Data.CreatedBy = wsInst.CreatedBy;
                        result.Data.ModifiedDate = wsInst.ModifiedDate;
                        result.Data.ModifiedBy = wsInst.ModifiedBy;
                        result.Data.OwnedBy = wsInst.OwnedBy;
                        result.Data.UserSignatureFileGUID = wsInst.UserSignatureFileGUID;
                        result.Data.CustomFormID = wsInst.CustomFormSurveyID;
                        result.Data.LearnerSignatureFileGUID = wsInst.LearnerSignatureFileGUID;
                        result.Data.EmpSignatureFileGUID = wsInst.EmpSignatureFileGUID;
                        result.Data.EmpBSignatureFileGUID = wsInst.EmpBSignatureFileGUID;
                        result.Data.EmpCSignatureFileGUID = wsInst.EmpCSignatureFileGUID;
                        result.Data.OfficerASignatureFileGUID = wsInst.OffASignatureFileGUID;
                        result.Data.OfficerBSignatureFileGUID = wsInst.OffBSignatureFileGUID;
                    }

                    if (res.ErrorDetails != null)
                    {
                        if (!string.IsNullOrEmpty(res.ErrorDetails.FurtherDetails))
                            result.ResponseText = res.ErrorDetails.FurtherDetails;
                        else
                            result.ResponseText = res.ErrorDetails.ErrorDescription;
                    }

                    return result;
                }
                catch (Exception ex)
                {
                   //Debug.writeLine(ex.Message);
                    throw;
                }
            });
        }

        public async Task<GenericResponse<List<DBFormInstance>>> GetForms()
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = ListResponse<DBFormInstance>();

                    GetFormListRequest req = NewRequest<GetFormListRequest>();
                    req.OwnerUsername = Settings.ClearUsername;
                    req.RequiredStatuses = fldFormCapCommon.FORMS_TO_DOWNLOAD_TO_TABLET + fldFormCapCommon.FORM_STATUS_ADMINDELETED;

                    GetFormListResponse res = webService.GetFormList(req);
                    HandleCommonResponse(res);


                    result.Data = new List<DBFormInstance>();
                    if (res.FormList != null)
                    {
                        if (res.FormList.Length > 0)
                        {
                            foreach (FormInstance wsForm in res.FormList)
                            {
                                DBFormInstance dbInst = new DBFormInstance();
                                dbInst.FormInstanceID = wsForm.FormInstanceID;
                                dbInst.Status = wsForm.Status;

                                if (dbInst.Status != fldFormCapCommon.FORM_STATUS_ADMINDELETED)
                                {
                                    GetFormRequest reqForm = NewRequest<GetFormRequest>();
                                    reqForm.FormInstanceID = wsForm.FormInstanceID;
                                    reqForm.IncludeFullData = true;
                                    //reqForm.IncludeFullDataSpecified = true;

                                    GetFormResponse resForm = webService.GetForm(reqForm);

                                    FormInstance oInst = resForm.FormInstance;
                                    dbInst.Title = oInst.Title;
                                    dbInst.FormType = oInst.FormType;
                                    dbInst.CreatedDate = oInst.CreatedDate;
                                    dbInst.CreatedBy = oInst.CreatedBy;
                                    dbInst.ModifiedDate = oInst.ModifiedDate;
                                    dbInst.ModifiedBy = oInst.ModifiedBy;
                                    dbInst.OwnedBy = oInst.OwnedBy;
                                    dbInst.UserSignatureFileGUID = oInst.UserSignatureFileGUID;
                                    dbInst.CustomFormID = oInst.CustomFormSurveyID;
                                    dbInst.LearnerSignatureFileGUID = oInst.LearnerSignatureFileGUID;
                                    dbInst.EmpSignatureFileGUID = oInst.EmpSignatureFileGUID;
                                    dbInst.EmpBSignatureFileGUID = oInst.EmpBSignatureFileGUID;
                                    dbInst.EmpCSignatureFileGUID = oInst.EmpCSignatureFileGUID;
                                    dbInst.OfficerASignatureFileGUID = oInst.OffASignatureFileGUID;
                                    dbInst.OfficerBSignatureFileGUID = oInst.OffBSignatureFileGUID;
                                    if (oInst.FormData != null)
                                    {
                                        for (int nAttachment = 1; nAttachment <= fldFormCapCommon.Max_AttachCount; nAttachment++)
                                        {
                                            DBFormInstanceAttachment oAttach = new DBFormInstanceAttachment();
                                            oAttach.FormInstanceID = oInst.FormInstanceID;
                                            oAttach.AttachmentNumber = nAttachment;
                                            oAttach.IndexID = string.Format("{0}_{1}", oAttach.FormInstanceID, oAttach.AttachmentNumber);
                                            dbInst.Attachments.Add(oAttach);
                                        }

                                        foreach (FormLine oLine in oInst.FormData)
                                        {
                                            DBFormField dbField = new DBFormField();
                                            dbField.FormInstanceID = oInst.FormInstanceID;

                                            dbField.FormType = oInst.FormType;
                                            dbField.FieldName = oLine.FieldName;
                                            dbField.RecGUID = oInst.FormInstanceID + dbField.FieldName;
                                            dbField.FieldType = oLine.FieldType;
                                            dbField.FieldValue = oLine.FieldValue;
                                            if (!dbInst.Fields.ContainsKey(dbField.FieldName))
                                                dbInst.Fields.Add(dbField.FieldName, dbField);
                                            else
                                               //Debug.writeLine("Duplicate fucking field: " + dbField.FieldName + " in form " + dbInst.Title + ": " + dbInst.FormInstanceID);

                                            if (!string.IsNullOrEmpty(oLine.FieldValue))
                                            {
                                                if (dbInst.IsFormField(dbField, "Orig_Form"))
                                                {
                                                    dbInst.OriginatingForm = dbField.FieldValue;
                                                }
                                                else if (dbInst.IsFormField(dbField, "CreateVersion"))
                                                {
                                                    dbInst.CreateVersion = dbField.FieldValue;
                                                }
                                                else if (dbInst.IsFormField(dbField, "LastModVersion"))
                                                {
                                                    dbInst.LastModVersion = dbField.FieldValue;
                                                }
                                                else if (dbInst.IsFormField(dbField, "HOFeedback"))
                                                {
                                                    dbInst.HOFeedBack = dbField.FieldValue;
                                                }
                                                else if (dbInst.IsFormField(dbField, "SurveyID"))
                                                {
                                                    if (string.IsNullOrEmpty(dbInst.CustomFormID))
                                                    {
                                                        dbInst.CustomFormID = dbField.FieldValue;
                                                    }
                                                }
                                                else if (dbInst.IsFormField(dbField, "Source_ApIdent"))
                                                {
                                                    dbInst.SourceApplicID = dbField.FieldValue;
                                                }
                                                else if (dbInst.IsFormField(dbField, "Source_EventId"))
                                                {
                                                    dbInst.SourceCRMEventID = Convert.ToInt32(dbField.FieldValue);
                                                }
                                                else if (dbField.FieldName.Contains("__ATTACH"))
                                                {
                                                    //process attachments
                                                    //Optimise to parse the field name, rather than checking for every possible file ID - done
                                                    string sAttachPostFix;

                                                    sAttachPostFix = dbField.FieldName.Substring(dbField.FieldName.Length - 2);
                                                    if (dbInst.IsFormField(dbField, string.Format("ATTACHFILEGUID{0}", sAttachPostFix))) //pcFilestore GUID
                                                    {
                                                        dbInst.Attachments[int.Parse(sAttachPostFix) - 1].FileGUID = dbField.FieldValue;
                                                    }
                                                    else if (dbInst.IsFormField(dbField, string.Format("ATTACHFILENAME{0}", sAttachPostFix))) //physical file name
                                                    {
                                                        dbInst.Attachments[int.Parse(sAttachPostFix) - 1].FileName = dbField.FieldValue;
                                                    }
                                                    else if (dbInst.IsFormField(dbField, string.Format("ATTACHNAME{0}", sAttachPostFix))) //will have been user prompted to enter this, defaulted to filename
                                                    {
                                                        dbInst.Attachments[int.Parse(sAttachPostFix) - 1].Name = dbField.FieldValue;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                result.Data.Add(dbInst);
                            }
                        }
                        else
                        {
                            //No forms found
                        }

                    }
                    else
                    {
                        if (res.ErrorDetails != null)
                        {
                            if (!string.IsNullOrEmpty(res.ErrorDetails.FurtherDetails))
                                result.ResponseText = res.ErrorDetails.FurtherDetails;
                            else
                                result.ResponseText = res.ErrorDetails.ErrorDescription;
                        }
                    }

                    return result;
                }
                catch (Exception ex)
                {
                   //Debug.writeLine(ex.Message);
                    throw;
                }
            });


        }

        public async Task<GenericResponse<List<DBCustomForm>>> GetCustomForms()
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = ListResponse<DBCustomForm>();

                    GetCustomFormListRequest req = NewRequest<GetCustomFormListRequest>();

                    req.IncludeDormant = false;
                    //req.IncludeDormantSpecified = true;
                    req.IncludeFormLines = true;
                    //req.IncludeFormLinesSpecified = true;

                    GetCustomFormListResponse res = webService.GetCustomFormList(req);
                    HandleCommonResponse(res);
                    result.Data = new List<DBCustomForm>();
                    if (res.CustomForms != null)
                    {
                        if (res.CustomForms.Length > 0)
                        {
                            foreach (CustomForm oInst in res.CustomForms)
                            {
                                DBCustomForm dbInst = new DBCustomForm();
                                dbInst.FormID = oInst.CustomFormID;
                                dbInst.Title = oInst.CustomFormTitle;
                                dbInst.Description = oInst.CustomFormDescription;
                                dbInst.IsFor = oInst.CustomFormIsFor;
                                dbInst.Status = oInst.CustomFormStatus;
                                dbInst.Type = oInst.CustomFormFormType;
                                dbInst.TemplateFileID = oInst.CustomFormTemplateFileID;

                                if (oInst.CustomFormLines != null)
                                {
                                    foreach (CustomFormLine oLine in oInst.CustomFormLines)
                                    {
                                        DBCustomFormQuestion dbQuestion = new DBCustomFormQuestion();
                                        dbQuestion.FormID = oInst.CustomFormID;
                                        dbQuestion.LineID = oLine.CustomFormLineID;
                                        dbQuestion.Type = oLine.CustomFormLineType;
                                        dbQuestion.Text = oLine.CustomFormLineText;
                                        dbQuestion.Sequence = oLine.CustomFormLineSequence;
                                        dbQuestion.Status = oLine.CustomFormLineStatus;
                                        dbQuestion.Layout = oLine.CustomFormLineLayout;
                                        dbQuestion.ImportFieldName = oLine.CustomFormLineImportFieldName;
                                        dbQuestion.ImportFieldType = oLine.CustomFormLineImportFieldType;
                                        dbQuestion.HelpText = oLine.CustomFormLineHelpText;

                                        dbQuestion.HelpText = oLine.CustomFormLineHelpText;
                                        StringBuilder slAnswers = new StringBuilder();
                                        foreach (string sAnswer in oLine.CustomFormLineAnswers)
                                        {
                                            slAnswers.AppendLine(sAnswer);
                                        }
                                        dbQuestion.Answers = slAnswers.ToString();

                                        //TODO: Check: Is this still needed?
                                        StringBuilder slValidation = new StringBuilder();
                                        foreach (CustomFormLineValidationRule oValidation in oLine.CustomFormLineValidationRules)
                                        {
                                            slValidation.AppendLine(oValidation.CustomFormValidationKey + "=" + oValidation.CustomFormValidationValue);
                                            if (oValidation.CustomFormValidationKey.ToUpper() == uSurveys.SAVAL_MANDATORY)
                                                dbQuestion.Mandatory = (oValidation.CustomFormValidationValue == "Y");
                                            else if (oValidation.CustomFormValidationKey.ToUpper() == uSurveys.SAVAL_MIN_VALUE)
                                                dbQuestion.MinVal = oValidation.CustomFormValidationValue;
                                            else if (oValidation.CustomFormValidationKey.ToUpper() == uSurveys.SAVAL_MAX_VALUE)
                                                dbQuestion.MaxVal = oValidation.CustomFormValidationValue;
                                            else if (oValidation.CustomFormValidationKey.ToUpper() == uSurveys.SAVAL_DEFAULT)
                                                dbQuestion.Default = oValidation.CustomFormValidationValue;
                                        }
                                        dbQuestion.Validation = slValidation.ToString();
                                        dbInst.Questions.Add(dbQuestion);
                                    }
                                }

                                result.Data.Add(dbInst);
                            }
                        }
                        else
                        {
                            //No forms found
                        }

                    }
                    else
                    {
                        if (res.ErrorDetails != null)
                        {
                            if (!string.IsNullOrEmpty(res.ErrorDetails.FurtherDetails))
                                result.ResponseText = res.ErrorDetails.FurtherDetails;
                            else
                                result.ResponseText = res.ErrorDetails.ErrorDescription;
                        }
                    }

                    return result;
                }
                catch (Exception ex)
                {
                   //Debug.writeLine(ex.Message);
                    throw;
                }
            });
        }

        public async Task<GenericResponse<bool>> UploadForm(DBFormInstance Form)
        {
            return await UploadForm(Form, string.Empty);
        }

        public async Task<GenericResponse<bool>> UploadForm(DBFormInstance Form, string FileGUID)
        {
            return await Task.Run(() =>
            {
                try
                {
                    GenericResponse<bool> result = SingleResponse<bool>();

                    SendFormRequest req = NewRequest<SendFormRequest>();
                    if (!string.IsNullOrEmpty(FileGUID))
                    {
                        req.FileGUID = FileGUID;
                    }
                    req.FormInstance = new FormInstance();
                    req.IncludesFormData = Form.Fields.Count > 0;
                    //req.IncludesFormDataSpecified = true;
                    req.FormInstance.CreatedBy = Form.CreatedBy;
                    req.FormInstance.CreatedDate = Form.CreatedDate;
                    //req.FormInstance.CreatedDateSpecified = true;
                    req.FormInstance.FormInstanceID = Form.FormInstanceID;
                    req.FormInstance.FormType = Form.FormType;
                    req.FormInstance.ModifiedBy = Form.ModifiedBy;
                    req.FormInstance.ModifiedDate = Form.ModifiedDate;
                    //req.FormInstance.ModifiedDateSpecified = true;
                    req.FormInstance.OwnedBy = Form.OwnedBy;
                    req.FormInstance.Status = Form.Status;
                    req.FormInstance.Title = Form.Title;
                    req.FormInstance.UserSignatureFileGUID = Form.UserSignatureFileGUID;
                    req.FormInstance.CustomFormSurveyID = Form.CustomFormID;
                    req.FormInstance.LearnerSignatureFileGUID = Form.LearnerSignatureFileGUID;
                    req.FormInstance.EmpSignatureFileGUID = Form.EmpSignatureFileGUID;
                    req.FormInstance.EmpBSignatureFileGUID = Form.EmpBSignatureFileGUID;
                    req.FormInstance.EmpCSignatureFileGUID = Form.EmpCSignatureFileGUID;
                    req.FormInstance.OffASignatureFileGUID = Form.OfficerASignatureFileGUID;
                    req.FormInstance.OffBSignatureFileGUID = Form.OfficerBSignatureFileGUID;
                    List<FormLine> slFields = new List<FormLine>();

                    foreach (DBFormField field in Form.Fields.Values)
                    {
                        FormLine line = new FormLine();

                        line.FieldName = field.FieldName;
                        line.FieldType = field.FieldType;
                        line.FieldValue = field.FieldValue;
                        line.RecGUID = field.RecGUID;
                        slFields.Add(line);
                    }
                    //file attachments fields

                    req.FormInstance.FormData = slFields.ToArray();

                    SendFormResponse res = webService.SendForm(req);
                    HandleCommonResponse(res);

                    if (res.ResponseStatus != 0) //Not sucess
                    {
                        StringBuilder slErrors = new StringBuilder();
                        slErrors.AppendLine(res.ResponseText);
                        if (res.ErrorDetails.DataValidation.Length > 0)
                        {
                            foreach (ValidationDetail val in res.ErrorDetails.DataValidation)
                            {
                                slErrors.AppendLine(val.ValidationText);
                            }
                        }

                        throw new Exception(slErrors.ToString());
                    }
                    result.Data = res.ResponseStatus == 0;

                    return result;
                }
                catch (Exception ex)
                {
                   //Debug.writeLine(ex.Message);
                    throw;
                }
            });
        }

        public async Task<GenericResponse<List<DBOfficer>>> GetOfficers()
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = ListResponse<DBOfficer>();
                    GetOfficerListRequest req = NewRequest<GetOfficerListRequest>();
                    req.RequiredFirstname = "%";
                    req.RequiredSurname = "%";
                    req.RequiredStatuses = "L";
                    req.RequiredRoles = "YZTMIEACP";

                    GetOfficerListResponse res = webService.GetOfficerList(req);
                    HandleCommonResponse(res);
                    result.Data = new List<DBOfficer>();
                    if (res.OfficerList != null)
                    {
                        if (res.OfficerList.Length > 0)
                        {
                            foreach (Officer wsOfficer in res.OfficerList)
                            {
                                DBOfficer dbOfficer = new DBOfficer();
                                dbOfficer.Officer = wsOfficer.Code;
                                dbOfficer.Firstname = wsOfficer.Forename;
                                dbOfficer.Surname = wsOfficer.Surname;
                                dbOfficer.Roles = wsOfficer.Roles;

                                result.Data.Add(dbOfficer);
                            }
                        }
                        else
                        {
                            //No Officers found
                        }
                    }
                    else
                    {
                        if (res.ErrorDetails != null)
                        {
                            if (!string.IsNullOrEmpty(res.ErrorDetails.FurtherDetails))
                                result.ResponseText = res.ErrorDetails.FurtherDetails;
                            else
                                result.ResponseText = res.ErrorDetails.ErrorDescription;
                        }
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public async Task<GenericResponse<List<DBOrganisation>>> GetOrganisations(string name, string postcode)
        {
            try
            {
                var result = ListResponse<DBOrganisation>();
                FindPlacementsRequest req = NewRequest<FindPlacementsRequest>();
                req.PlacementName = name;
                req.Postcode = postcode;
                FindPlacementsResponse res = webService.FindPlacements(req);
                HandleCommonResponse(res);
                result.Data = new List<DBOrganisation>();
                if (res.Placements != null && res.Placements.Length > 0)
                {
                    foreach (Placement wsPlacement in res.Placements)
                    {
                        DBOrganisation dbOrg = PlacementToDBOrg(wsPlacement);

                        if (!string.IsNullOrWhiteSpace(dbOrg.HeadOffice))
                        {
                            if (await App.DB.GetOrganisationByPlace(dbOrg.HeadOffice) == null)
                            {
                                GenericResponse<DBOrganisation> headOffice = await GetSingleOrganisationByPlace(dbOrg.HeadOffice);
                                await App.DB.SaveOrganisation(headOffice.Data);
                            }
                        }
                        result.Data.Add(dbOrg);
                    }
                }
                else
                {
                    if (res.ErrorDetails != null)
                    {
                        if (!string.IsNullOrEmpty(res.ErrorDetails.FurtherDetails))
                            result.ResponseText = res.ErrorDetails.FurtherDetails;
                        else
                            result.ResponseText = res.ErrorDetails.ErrorDescription;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(ex.Message);
                throw;
            }
        }

        private Placement PreparePlacementWS(DBOrganisation Org)
        {
            Placement _placement = new Placement();
            _placement.RecGUID = Org.RecGUID;
            _placement.PlacementName = Org.Name;
            _placement.Address = new Address();
            _placement.Address.Address1 = Org.Address1;
            _placement.Address.Address2 = Org.Address2;
            _placement.Address.Address3 = Org.Address3;
            _placement.Address.Address4 = Org.Address4;
            _placement.Address.Address5 = Org.Address5;
            _placement.Address.PostCode = Org.PostCode;
            _placement.Telephone = Org.Phone;
            _placement.WebsiteURL = Org.Website;
            _placement.Email = Org.Email;
            _placement.EdsERN = Org.EdsERN;
            _placement.Roles = Org.Roles;
            _placement.Company = Org.HeadOffice;
            if (_placement.Roles == null)
                _placement.Roles = string.Empty;
            if (!_placement.Roles.Contains("P"))
                _placement.Roles += "P";
            if (Settings.ServiceSupports(Settings.ServiceFeatures.ContactPreferences))
            {
                _placement.AllowedContactMethods = Org.AllowedContactMethods;
                _placement.PreferredContactMethod = Org.PreferredContactMethod;
            }
            if (!string.IsNullOrEmpty(Org.MainContactCode))
            {
                _placement.MainContact = new Officer();
                _placement.MainContact.Code = Org.MainContactCode;
                _placement.MainContact.Forename = Org.MainContactFirstname;
                _placement.MainContact.Surname = Org.MainContactSurname;
                _placement.MainContact.Telephone = Org.MainContactPhone;
                _placement.MainContact.Mobile = Org.MainContactMobile;
                _placement.MainContact.Email = Org.MainContactEmail;
            }
            return _placement;
        }

        public async Task<GenericResponse<string>> AddOrg(DBOrganisation Org)
        {
            return await Task.Run(() =>
            {
                try
                {
                    GenericResponse<string> result = SingleResponse<string>();

                    AddPlacementRequest req = NewRequest<AddPlacementRequest>();
                    req.Placement = PreparePlacementWS(Org);
                    AddPlacementResponse res = webService.AddPlacement(req);
                    HandleCommonResponse(res);
                    if ((res.Placement != null) && !string.IsNullOrEmpty(res.Placement.Code))
                    {
                        result.Data = res.Placement.Code;
                    }
                    else
                    {
                        if (res.ErrorDetails != null)
                        {
                            if ((res.ErrorDetails.DataValidation != null) && (res.ErrorDetails.DataValidation.Count() > 0))
                            {
                                StringBuilder slValidation = new StringBuilder();
                                foreach (var validation in res.ErrorDetails.DataValidation)
                                    slValidation.AppendLine(validation.ValidationText);
                                throw new Exception("AddOrg Validation Details: " + slValidation.ToString());
                            }
                            else
                            {
                                throw new Exception("AddOrg Error Details: " + res.ErrorDetails.ErrorDescription);
                            }
                        }
                        else if (res.ResponseStatus != 0) //Not sucess - checking this after checking for a place code and error details because of issues in webservice sometimes giving me a valid insert without a valid response status due to warnings. CFT
                        {
                            throw new Exception(res.ResponseText);
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public async Task<GenericResponse<bool>> UpdateOrg(DBOrganisation Org)
        {
            return await Task.Run(() =>
            {
                try
                {
                    GenericResponse<bool> result = SingleResponse<bool>();

                    UpdatePlacementRequest req = NewRequest<UpdatePlacementRequest>();
                    req.Placement = PreparePlacementWS(Org);

                    UpdatePlacementResponse res = webService.UpdatePlacement(req);
                    HandleCommonResponse(res);

                    if (res.ResponseStatus != 0) //Not sucess
                    {
                        throw new Exception(res.ResponseText);
                    }
                    result.Data = res.ResponseStatus == 0;

                    return result;
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public async Task<GenericResponse<DBOrganisation>> GetSingleOrganisationByGUID(string RecGUID)
        {
            return await Task.Run(() =>
            {
                try
                {
                    GenericResponse<DBOrganisation> result = null;
                    GetSinglePlacementByRecGUIDRequest req = new GetSinglePlacementByRecGUIDRequest();
                    req.PlaceRecGUID = RecGUID;
                    GetSinglePlacementByRecGUIDResponse res = webService.GetSinglePlacementByRecGUID(req);
                    HandleCommonResponse(res);

                    if (res.ResponseStatus != 0) //Not sucess
                    {
                        throw new Exception(res.ResponseText);
                    }

                    result = SingleResponse<DBOrganisation>();
                    result.Data = PlacementToDBOrg(res.Placement);

                    if (!string.IsNullOrWhiteSpace(result.Data.HeadOffice))
                    {
                        Task.Run(async () =>
                        {
                            if (await App.DB.GetOrganisationByPlace(result.Data.HeadOffice) == null)
                            {
                                GenericResponse<DBOrganisation> headOffice = await GetSingleOrganisationByPlace(result.Data.HeadOffice);
                                await App.DB.SaveOrganisation(headOffice.Data);
                            }
                        });

                    }

                    return result;
                }
                catch (Exception ex)
                {
                    //Xamarin.Insights.Report(ex, "Process", "GetSingleOrganisationByGUID",//Xamarin.Insights.Severity.Error);
                    //Debug.WriteLine(ex.Message);
                    return null;
                }
            });
        }

        public async Task<GenericResponse<DBOrganisation>> GetSingleOrganisationByPlace(string PlaceCode)
        {
            return await Task.Run(() =>
            {
                try
                {
                    GenericResponse<DBOrganisation> result = null;
                    GetSinglePlacementRequest req = NewRequest<GetSinglePlacementRequest>();
                    req.PlaceCode = PlaceCode;
                    GetSinglePlacementResponse res = webService.GetSinglePlacement(req);
                    HandleCommonResponse(res);

                    if (res.ResponseStatus != 0) //Not sucess
                    {
                        throw new Exception(res.ResponseText);
                    }

                    result = SingleResponse<DBOrganisation>();
                    result.Data = PlacementToDBOrg(res.Placement);

                    if (!string.IsNullOrWhiteSpace(result.Data.HeadOffice))
                    {
                        Task.Run(async () =>
                        {
                            if (await App.DB.GetOrganisationByPlace(result.Data.HeadOffice) == null)
                            {
                                GenericResponse<DBOrganisation> headOffice = await GetSingleOrganisationByPlace(result.Data.HeadOffice);
                                await App.DB.SaveOrganisation(headOffice.Data);
                            }
                        });

                    }

                    return result;
                }
                catch (Exception ex)
                {
                    //Xamarin.Insights.Report(ex, "Process", "GetSingleOrganisationByPlace",//Xamarin.Insights.Severity.Error);
                    //Debug.WriteLine(ex.Message);
                    return null;
                }
            });
        }

        private DBOrganisation PlacementToDBOrg(Placement placement)
        {
            DBOrganisation Result = new DBOrganisation()
            {
                Name = placement.PlacementName,
                Place = placement.Code,
                PostCode = placement.Address.PostCode,
                Address1 = placement.Address.Address1,
                Address2 = placement.Address.Address2,
                Address3 = placement.Address.Address3,
                Address4 = placement.Address.Address4,
                Address5 = placement.Address.Address5,
                RecGUID = placement.RecGUID,
                EdsERN = placement.EdsERN,
                Email = placement.Email,
                Roles = placement.Roles,
                Website = placement.WebsiteURL,
                Phone = placement.InvoicePhone,
                Status = placement.Status,
                SysStatus = placement.SysStatus,
                HeadOffice = placement.Company,
                SyncStatus = fldFormCapCommon.FCA_Org_Status_Unmodified
            };
            if (Settings.ServiceSupports(Settings.ServiceFeatures.ContactPreferences))
            {
                Result.AllowedContactMethods = placement.AllowedContactMethods;
                Result.PreferredContactMethod = placement.PreferredContactMethod;
            }
            return Result;
        }

        public async Task<GenericResponse<List<DBSite>>> GetSites()
        {
            GenericResponse<List<PicklistItem>> sites = await GetPickList(PicklistType.ptSite);

            var result = ListResponse<DBSite>();

            result.Data = new List<DBSite>();
            if (sites.Data != null)
            {
                if (sites.Data.Count > 0)
                {
                    foreach (PicklistItem oInst in sites.Data)
                    {
                        DBSite dbSite = new DBSite();
                        dbSite.Site = oInst.Code;
                        dbSite.Description = oInst.Description;
                        result.Data.Add(dbSite);
                    }
                }
                else
                {
                    //No sites found
                }
            }
            return result;
        }

        public async Task<GenericResponse<byte[]>> DownloadFile(string Guid)
        {
            return await Task.Run(() =>
            {
                try
                {
                    GenericResponse<byte[]> result = SingleResponse<byte[]>();

                    GetAttachedFileRequest req = NewRequest<GetAttachedFileRequest>();
                    req.FileGUID = Guid;
                    byte[] res;

                    //this changed
                    using (MemoryStream ms = new MemoryStream())
                    {
                        webService.GetAttachedFileAsStream(req).CopyTo(ms);
                        res = ms.ToArray();
                    }

                    if (res.Length == 0)
                    {
                        throw new Exception("No file data returned.");
                    }
                    result.Data = res;

                    return result;
                }
                catch (Exception ex)
                {
                   //Debug.writeLine(ex.Message);
                    throw;
                }
            });
        }

        public async Task<GenericResponse<string>> UploadAttachment(string FileName, Stream FileBody)
        {
            return await Task.Run(() =>
            {
                try
                {
                    GenericResponse<string> result = SingleResponse<string>();

                    UploadFileAsBytesRequest req = NewRequest<UploadFileAsBytesRequest>();

                    req.File = new FileData();
                    req.File.Name = FileName;
                    req.File.Data = new byte[FileBody.Length];
                    FileBody.Read(req.File.Data, 0, Convert.ToInt32(FileBody.Length));
                    UploadFileAsBytesResponse res = webService.UploadFileBytes(req);
                    HandleCommonResponse(res);


                    if (res.ResponseStatus != 0) //Not sucess
                    {
                        throw new Exception(res.ResponseText);
                    }
                    result.Data = res.AttachedFile.FileGUID;
                    return result;
                }
                catch (Exception ex)
                {
                   //Xamarin.Insights.Report(ex, "Process", "UploadAttachment",//Xamarin.Insights.Severity.Error);
                   //Debug.writeLine(ex.Message);
                    //todo handle an error report
                    return null;
                }
            });
        }
    }
}
