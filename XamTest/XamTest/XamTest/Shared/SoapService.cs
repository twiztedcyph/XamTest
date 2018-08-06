using PICSWebService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            picsService = new PICSWebServiceClient(PICSWebServiceClient.EndpointConfiguration.BasicHttpBinding_IPICSWebService, "http://ian2017.valhalla.local/PICSWebService/PICSWebService.svc");
            //if (!string.IsNullOrEmpty(Settings.WebServiceURL))
            //    picsService = new PICSWebServiceClient(Settings.WebServiceURL);
            //else
            //    picsService = new PICSWebServiceClient("http://ian2017.valhalla.local/PICSWebService/PICSWebService.svc");
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

        public async Task<SimpleServiceTestResponse> TestWS(string test)
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

        public async Task<GenericResponse<List<DBApplicant>>> FindApplicants(FindApplicantsSoapRequest findApplicants)
        {
            return await Task.Run(() =>
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
                    req.RecruitmentOfficer = Settings.OfficerCode;
                    req.Site = findApplicants.Sites;
                    req.Status = Settings.GetString("L", string.Empty);

                    SearchForApplicantsResponse1 res = picsService.SearchForApplicantsAsync(new SearchForApplicantsRequest1(req)).Result;
                    HandleCommonResponse(res.SearchForApplicantsResult);

                    // Error on failed response, but allow ErrorCode=2 (not found)
                    if ((res.SearchForApplicantsResult.ResponseStatus != 0) && (res.SearchForApplicantsResult.ErrorDetails != null) && (res.SearchForApplicantsResult.ErrorDetails.ErrorCode != 2)) //Not success
                    {
                        throw new Exception(res.SearchForApplicantsResult.ResponseText);
                    }

                    result = ListResponse<DBApplicant>();
                    result.Data = new List<DBApplicant>();
                    if (res.SearchForApplicantsResult.Applicants != null)
                    {
                        for (int i = 0; i < res.SearchForApplicantsResult.Applicants.Count(); i++)
                        {
                            // Only add live applicants (not deleted or ~)
                            //if (res.SearchForApplicantsResult.Applicants[i].SysStatus.Equals("L"))
                                //result.Data.Add(ApplicantToDBApplicant(res.SearchForApplicantsResult.Applicants[i]));
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    //Xamarin.Insights.Report(ex, "Process", "FindApplicants", Xamarin.Insights.Severity.Error);
                    //Debug.WriteLine(ex.Message);
                    return null;
                }
            });
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

        Task<string> ISoapService.TestWS(string test)
        {
            throw new NotImplementedException();
        }
    }
}
