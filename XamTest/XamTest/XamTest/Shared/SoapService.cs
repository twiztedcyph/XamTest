#if __ANDROID__
//using Pellcomp.Vs.Mobile.FormCaptureApp.Droid.PICSWS;
#endif
#if __IOS__
//using Pellcomp.Vs.Mobile.FormCaptureApp.iOS.PICSWS;
#endif
#if __UWP__

#endif
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using XamTest.Models;

namespace XamTest.Shared
{
    class SoapService : ISoapService
    {
        public Task<GenericResponse<string>> AddOrg(DBOrganisation Org)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<bool>> AuthenticateUser(string URL, string username, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<byte[]>> DownloadFile(string Guid)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<List<DBApplicant>>> FindApplicants(FindApplicantsSoapRequest findApplicants)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<List<DBLearner>>> FindLearners(FindLearnersSoapRequest findLearners)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<List<DBPickItem>>> GetAllPickItems()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<string>> GetConfig(string Section, string Key)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<List<DBCustomForm>>> GetCustomForms()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<Dictionary<string, string>>> GetFileData(string FileGUID)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<DBFormInstance>> GetFormHeaderFromServer(string FormID)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<List<DBFormInstance>>> GetForms()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<List<DBOfficer>>> GetOfficers()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<List<DBOrganisation>>> GetOrganisations(string name, string postcode)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<List<DBQualPlan>>> GetPlans()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<DBOrganisation>> GetSingleOrganisationByGUID(string RecGUID)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<DBOrganisation>> GetSingleOrganisationByPlace(string PlaceCode)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<List<DBSite>>> GetSites()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<Dictionary<string, string>>> GetSystemInfo(bool fullDetails = false)
        {
            throw new NotImplementedException();
        }

        public Task<string> TestWS(string test)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<bool>> UpdateOrg(DBOrganisation Org)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<string>> UploadAttachment(string FileName, Stream FileBody)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<bool>> UploadForm(DBFormInstance Form)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<bool>> UploadForm(DBFormInstance Form, string FileGUID)
        {
            throw new NotImplementedException();
        }
    }
}
