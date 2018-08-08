using FCA.Interfaces;
using FCA.Models;
using Pellcomp.Vs.Mobile.FormCaptureApp.lib;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FCA.Helpers
{
    public class Database
    {
        public SQLiteConnection NonAsyncDb { get; set; } = DependencyService.Get<IDatabase>().DbConnection();
        public SQLiteAsyncConnection AsyncDb { get; set; } = DependencyService.Get<IDatabase>().DbAsyncConnection();

        public void CreateTables()
        {
            NonAsyncDb.CreateTable<UserAccount>();
            NonAsyncDb.CreateTable<DBCustomForm>();
            NonAsyncDb.CreateTable<DBCustomFormQuestion>();
            NonAsyncDb.CreateTable<DBFormInstance>();
            NonAsyncDb.CreateTable<DBFormField>();
            NonAsyncDb.CreateTable<DBFormInstanceAttachment>();
            NonAsyncDb.CreateTable<DBQualPlan>();
            NonAsyncDb.CreateTable<DBQualPlanDet>();
            NonAsyncDb.CreateTable<DBSite>();
            NonAsyncDb.CreateTable<DBPickItem>();
            NonAsyncDb.CreateTable<DBOfficer>();
            NonAsyncDb.CreateTable<DBOrganisation>();
            NonAsyncDb.CreateTable<DBLearner>();
            NonAsyncDb.CreateTable<DBApplicant>();
        }

        public void DropAndCreateDatabase()
        {
            NonAsyncDb.TableMappings.ForEach(table => { NonAsyncDb.DropTable(table); });
            CreateTables();
        }

        public async Task<UserAccount> GetAccount()
        {
            int nCount = await AsyncDb.Table<UserAccount>().CountAsync();
            if (nCount > 0)
            {
                return await AsyncDb.Table<UserAccount>().FirstAsync();
            }
            else
            {
                return new UserAccount();
            }
        }

        public async Task<int> UpdateAccount(UserAccount Account)
        {
            await DeleteAccount();
            return await AsyncDb.InsertAsync(Account);
        }

        internal async Task<int> DeleteAccount()
        {
            UserAccount oAccount = await AsyncDb.Table<UserAccount>().FirstOrDefaultAsync();
            if (oAccount != null)
                return await AsyncDb.DeleteAsync(oAccount);
            else
                return -1;
        }

        private async Task SetupForm(DBFormInstance form)
        {
            DBCustomForm oCustom = await GetCustomForm(form.CustomFormID);
            form.CustomFormTypeTitle = oCustom?.Title;
            form.StatusText = fldFormCapCommon.StatusList[form.Status];
        }

        public async Task<List<DBOfficer>> GetOfficers(string type)
        {
            List<DBOfficer> oOfficers = await AsyncDb.Table<DBOfficer>().Where(f => f.Roles.Contains(type)).OrderBy(o => o.Surname).ThenBy(n => n.Firstname).ToListAsync();

            return oOfficers;
        }

        public async Task<List<DBFormInstance>> GetForms(bool IncludeFields)
        {
            List<DBFormInstance> oForms = await AsyncDb.Table<DBFormInstance>().OrderBy(f => f.CreatedDate).ToListAsync();

            foreach (DBFormInstance form in oForms)
            {
                await SetupForm(form);
                if (IncludeFields)
                {
                    List<DBFormField> _fields = await AsyncDb.Table<DBFormField>().Where(fld => fld.FormInstanceID == form.FormInstanceID).ToListAsync();
                    form.Fields = new Dictionary<string, DBFormField>();
                    foreach (DBFormField field in _fields)
                        form.Fields.Add(field.FieldName, field);

                    form.Attachments = await AsyncDb.Table<DBFormInstanceAttachment>().Where(a => a.FormInstanceID == form.FormInstanceID).ToListAsync();
                }
            }
            return oForms;
        }

        public async Task<List<DBCustomForm>> GetCustomForms()
        {
            return await AsyncDb.Table<DBCustomForm>().OrderBy(it => it.Type).ToListAsync();
        }

        public async Task<DBFormInstance> GetForm(string FormID)
        {
            DBFormInstance form = await AsyncDb.Table<DBFormInstance>().Where(x => x.FormInstanceID == FormID).FirstOrDefaultAsync();
            if (form != null)
            {
                await SetupForm(form);
                List<DBFormField> _fields = await AsyncDb.Table<DBFormField>().Where(fld => fld.FormInstanceID == form.FormInstanceID).ToListAsync();
                form.Fields = new Dictionary<string, DBFormField>();
                foreach (DBFormField field in _fields)
                    form.Fields.Add(field.FieldName, field);
                List<DBFormInstanceAttachment> _attachments = await AsyncDb.Table<DBFormInstanceAttachment>().Where(fld => fld.FormInstanceID == form.FormInstanceID).ToListAsync();
                foreach (DBFormInstanceAttachment attach in _attachments)
                    form.Attachments.Add(attach);
            }
            return form;
        }

        public async Task<DBFormField> GetFormField(string RecGUID)
        {
            return await AsyncDb.Table<DBFormField>().Where(x => x.RecGUID == RecGUID).FirstOrDefaultAsync();
        }

        public async Task<List<DBFormInstance>> SearchForms(string SearchText)
        {
            SearchText = SearchText.ToUpper();
            List<DBFormInstance> allForms = await GetForms(false);
            List<DBFormInstance> searchResults = new List<DBFormInstance>();
            foreach (DBFormInstance form in allForms)
            {
                if (form.Title.ToUpper().Contains(SearchText))
                {
                    searchResults.Add(form);
                }
            }
            return searchResults;
        }

        public async Task<List<DBCustomForm>> SearchCustomForms(string searchText)
        {
            searchText = searchText.ToUpper();
            return await AsyncDb.Table<DBCustomForm>().Where(it => it.Title.ToUpper().Contains(searchText)).ToListAsync();
        }

        public async Task<int> SaveForm(DBFormInstance form)
        {
            try
            {
                if (await GetForm(form.FormInstanceID) != null)
                {
                    return await AsyncDb.UpdateAsync(form);
                }
                else
                {
                    return await AsyncDb.InsertAsync(form);
                }



                //save attachments too from form.Attachments
            }
            catch (Exception ex)
            {
                //Insights.Report(ex);
                throw;
            }

        }


        public async Task<int> SaveFormAttachment(DBFormInstanceAttachment attach)
        {
            DBFormInstanceAttachment _existing = await AsyncDb.Table<DBFormInstanceAttachment>().Where(x => x.IndexID == attach.IndexID).FirstOrDefaultAsync();
            if (_existing == null)
            {
                return await AsyncDb.InsertAsync(attach);
            }
            else
            {
                return await AsyncDb.UpdateAsync(attach);
            }
        }

        public async Task<int> SaveFormField(DBFormField field)
        {
            if (!string.IsNullOrEmpty(field.RecGUID) && (await GetFormField(field.RecGUID) != null))
            {
                return await AsyncDb.UpdateAsync(field);
            }
            else
            {
                return await AsyncDb.InsertAsync(field);
            }
        }
        public async Task<int> DeleteForm(string FormID)
        {
            DBFormInstance oForm = await GetForm(FormID);
            if (oForm != null)
            {
                foreach (var field in oForm.Fields)
                {
                    await AsyncDb.DeleteAsync(field.Value);
                }
                foreach (var attach in oForm.Attachments)
                {
                    await AsyncDb.DeleteAsync(attach);
                }
                return await AsyncDb.DeleteAsync(oForm);
            }
            else
                return -1;
        }


        public async Task<DBCustomForm> GetCustomForm(string FormID)
        {
            DBCustomForm form = await AsyncDb.Table<DBCustomForm>().Where(x => x.FormID == FormID).FirstOrDefaultAsync();
            if ((form != null) && !string.IsNullOrEmpty(form.FormID))
            {
                form.Questions = await AsyncDb.Table<DBCustomFormQuestion>().Where(q => q.FormID == form.FormID).ToListAsync();
            }
            return form;
        }

        public void Start()
        {
            //Do Nothing Just cause app to create DB early
        }

        public async Task<List<DBOrganisation>> GetOrgsBySyncStatus(string SyncStatus)
        {
            return await AsyncDb.Table<DBOrganisation>().Where(org => org.SyncStatus == SyncStatus).ToListAsync();
        }

        public async Task<List<DBOrganisation>> GetOrgsWithPlace()
        {
            //NullOrWhitespace not available in Linq.
            return await AsyncDb.Table<DBOrganisation>().Where(org => org.Place != null).ToListAsync();
        }

        public async Task<List<DBOrganisation>> GetOrganisations()
        {
            return await AsyncDb.Table<DBOrganisation>().OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<DBOrganisation>> GetOrganisations(string Role)
        {
            return await AsyncDb.Table<DBOrganisation>().Where(x => x.Roles.Contains(Role)).OrderBy(x => x.Name).ToListAsync();
        }
        public async Task<List<DBOrganisation>> SearchOrganisations(string searchText)
        {
            return await AsyncDb.Table<DBOrganisation>().Where(x => x.Name.ToUpper().Contains(searchText.ToUpper())).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<DBOrganisation> GetOrganisationByGUID(string RecGUID)
        {
            return await AsyncDb.Table<DBOrganisation>().Where(x => x.RecGUID == RecGUID).FirstOrDefaultAsync();
        }

        public async Task<DBOrganisation> GetOrganisationByPlace(string Place)
        {
            return await AsyncDb.Table<DBOrganisation>().Where(x => x.Place == Place).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteSingleOrganisation(DBOrganisation org)
        {
            if (org != null && !string.IsNullOrWhiteSpace(org.SyncStatus) && !(await OrgIsNewUsedModified(org)))
            {
                return await AsyncDb.DeleteAsync(org) > 0;
            }
            return false;
        }

        private async Task<bool> OrgIsNewUsedModified(DBOrganisation org)
        {
            //Easier check 1st
            if (org.SyncStatus.Equals(fldFormCapCommon.FCA_Org_Status_New) || org.SyncStatus.Equals(fldFormCapCommon.FCA_Org_Status_Modified))
                return true;

            DBFormField foundField = await AsyncDb.Table<DBFormField>().Where(x => x.FieldValue.Equals(org.RecGUID)).FirstOrDefaultAsync();
            if (foundField != null)
                return true;

            return await AsyncDb.Table<DBOrganisation>().Where(x => x.Place.Equals(org.HeadOffice)).FirstOrDefaultAsync() != null;
        }

        public async Task ClearUnusedOrgs()
        {
            List<DBOrganisation> allOrgs = await GetOrgsBySyncStatus(fldFormCapCommon.FCA_Org_Status_Unmodified);
            foreach (DBOrganisation org in allOrgs)
            {
                await DeleteSingleOrganisation(org);
            }
        }

        public async Task<int> SaveOrganisation(DBOrganisation dbOrg)
        {
            if (await GetOrganisationByGUID(dbOrg.RecGUID) != null)
            {
                return await AsyncDb.UpdateAsync(dbOrg);
            }
            else
            {
                return await AsyncDb.InsertAsync(dbOrg);
            }
        }

        internal async Task<List<DBSite>> GetSites()
        {
            return await AsyncDb.Table<DBSite>().ToListAsync();
        }

        internal async Task<List<DBQualPlan>> GetQualPlans()
        {
            return await AsyncDb.Table<DBQualPlan>().ToListAsync();
        }

        internal async Task<List<DBQualPlanDet>> GetQualPlanDets(string PlanCode)
        {
            return await AsyncDb.Table<DBQualPlanDet>().Where(X => X.PlanCode == PlanCode).ThenBy(X => X.QualCode).ToListAsync();
        }

        public async Task<List<DBLearner>> GetLearners()
        {
            return await AsyncDb.Table<DBLearner>().OrderBy(x => x.Surname).ThenBy(x => x.Firstname).ToListAsync();
        }

        public async Task<DBLearner> GetLearnerByIdent(string Ident)
        {
            return await AsyncDb.Table<DBLearner>().Where(x => x.Ident == Ident).FirstOrDefaultAsync();
        }

        public async Task<List<DBLearner>> SearchLearnersByName(string nameSearchText)
        {
            return await AsyncDb.Table<DBLearner>().Where(x => x.Surname.ToUpper().Contains(nameSearchText.ToUpper()) || x.Firstname.ToUpper().Contains(nameSearchText.ToUpper())).OrderBy(x => x.Surname).ThenBy(x => x.Firstname).ToListAsync();
        }

        public async Task<int> SaveLearner(DBLearner dbLrnr)
        {
            if (await GetLearnerByIdent(dbLrnr.Ident) != null)
            {
                return await AsyncDb.UpdateAsync(dbLrnr);
            }
            else
            {
                return await AsyncDb.InsertAsync(dbLrnr);
            }
        }

        public async Task<bool> DeleteSingleLearner(DBLearner learner)
        {
            if (learner != null)
            {
                return await AsyncDb.DeleteAsync(learner) > 0;
            }
            return false;
        }

        public async Task<bool> DeleteLearnersByDownloadDate(DateTime downloadedBefore)
        {
            if (downloadedBefore != DateTime.MinValue)
            {
                bool Result = true;
                var query = from lnr in AsyncDb.Table<DBLearner>()
                            where lnr.Downloaded < downloadedBefore
                            select lnr;
                List<DBLearner> lnrsToDelete = await query.ToListAsync();
                foreach (DBLearner lnr in lnrsToDelete)
                    Result &= await DeleteSingleLearner(lnr);
                return Result;
            }
            return false;
        }

        private AsyncTableQuery<DBApplicant> GetApplicantsTable()
        {
            return AsyncDb.Table<DBApplicant>().OrderBy(x => x.Surname).ThenBy(x => x.Forenames);
        }

        public async Task<List<DBApplicant>> GetApplicants()
        {
            return await GetApplicantsTable().ToListAsync();
        }

        public async Task<List<DBApplicant>> SearchApplicants(string searchText)
        {
            return await GetApplicantsTable().Where(x => x.Forenames.ToUpper().Contains(searchText.ToUpper()) || x.Surname.ToUpper().Contains(searchText.ToUpper()) || x.PostCode.ToUpper().Contains(searchText.ToUpper())).ToListAsync();
        }

        public async Task<DBApplicant> GetApplicant(string apIdent)
        {
            return await AsyncDb.Table<DBApplicant>().Where(x => x.ApIdent == apIdent).FirstOrDefaultAsync();
        }

        public async Task<DBApplicant> GetApplicantByRecGUID(string RecGUID)
        {
            return await AsyncDb.Table<DBApplicant>().Where(x => x.RecGUID == RecGUID).FirstOrDefaultAsync();
        }

        public async Task<int> SaveApplicant(DBApplicant dbApplicant)
        {
            if (await GetApplicantByRecGUID(dbApplicant.RecGUID) != null)
            {
                return await AsyncDb.UpdateAsync(dbApplicant);
            }
            else
            {
                return await AsyncDb.InsertAsync(dbApplicant);
            }
        }
        public async Task<bool> DeleteApplicant(DBApplicant dbApplicant)
        {
            if (dbApplicant != null)
            {
                return await AsyncDb.DeleteAsync(dbApplicant) > 0;
            }
            return false;
        }

        public async Task<bool> DeleteApplicantsByDownloadDate(DateTime downloadedBefore)
        {
            if (downloadedBefore != DateTime.MinValue)
            {
                bool Result = true;
                var query = from applicant in AsyncDb.Table<DBApplicant>()
                            where applicant.Downloaded < downloadedBefore
                            select applicant;
                List<DBApplicant> applicantsToDelete = await query.ToListAsync();
                foreach (DBApplicant applicant in applicantsToDelete)
                    Result &= await DeleteApplicant(applicant);
                return Result;
            }
            return false;
        }
    }
}
