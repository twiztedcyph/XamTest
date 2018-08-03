using PICSWebService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using XamTest.Helpers;
using XamTest.Models;

namespace XamTest.Shared
{
    class SoapService : ISoapService
    {
        private readonly PICSWebServiceClient picsService;
        public SoapService()
        {
            if (!string.IsNullOrEmpty(Settings.WebServiceURL))
                picsService = new PICSWebServiceClient(Settings.WebServiceURL);
            else
                picsService = new PICSWebServiceClient();
        }

        private void HandleCommonResponse(PublicPICSResponse response)
        {
            if (!string.IsNullOrEmpty(response.NewAuthToken)) //new auth token has been generated. 
                Settings.AuthToken = response.NewAuthToken;
            //if (response.ResponseStatus == 8)
                //App.Current.HadAuthenticationError = true;
        }

        private T NewRequest<T>() where T : PublicPICSRequest, new()
        {
            T result = new T();
            result.Username = Settings.UserName;
            result.Password = Settings.Password;
            result.AuthToken = Settings.AuthToken;
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
                SimpleServiceTestRequest request = new SimpleServiceTestRequest()
                {
                    sInputText = test
                };
                return picsService.SimpleServiceTestAsync(request);
            });
        }

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
