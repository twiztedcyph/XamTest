using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FCA.Models;
using FCA.Shared;

namespace FCA.Interfaces
{
    public interface ISoapService
    {
        Task<string> TestWS(string test);
        Task<GenericResponse<bool>> AuthenticateUser(string username, string Password);
        Task<GenericResponse<DBFormInstance>> GetFormHeaderFromServer(string FormID);
        Task<GenericResponse<List<DBFormInstance>>> GetForms();
        Task<GenericResponse<List<DBCustomForm>>> GetCustomForms();
        Task<GenericResponse<List<DBQualPlan>>> GetPlans();
        Task<GenericResponse<string>> GetConfig(string Section, string Key);
        Task<GenericResponse<List<DBSite>>> GetSites();
        Task<GenericResponse<List<DBOfficer>>> GetOfficers();
        Task<GenericResponse<List<DBPickItem>>> GetAllPickItems();
        Task<GenericResponse<bool>> UploadForm(DBFormInstance Form);
        Task<GenericResponse<bool>> UploadForm(DBFormInstance Form, string FileGUID);
        Task<GenericResponse<string>> AddOrg(DBOrganisation Org);
        Task<GenericResponse<bool>> UpdateOrg(DBOrganisation Org);
        Task<GenericResponse<byte[]>> DownloadFile(string Guid);
        Task<GenericResponse<string>> UploadAttachment(string FileName, Stream FileBody);
        Task<GenericResponse<List<DBOrganisation>>> GetOrganisations(string name, string postcode);
        Task<GenericResponse<Dictionary<string, string>>> GetFileData(string FileGUID);
        Task<GenericResponse<DBOrganisation>> GetSingleOrganisationByGUID(string RecGUID);
        Task<GenericResponse<Dictionary<string, string>>> GetSystemInfo(bool fullDetails = false);
        Task<GenericResponse<DBOrganisation>> GetSingleOrganisationByPlace(string PlaceCode);
        Task<GenericResponse<List<DBLearner>>> FindLearners(FindLearnersSoapRequest findLearners);
        Task<GenericResponse<List<DBApplicant>>> FindApplicants(FindApplicantsSoapRequest findApplicants);
    }

    public class FindLearnersSoapRequest
    {
        public string Surname;
        public string Forename;
        public string Postcode;
        public string MainOfficer;
        public string Sites;
    }
    public class FindApplicantsSoapRequest
    {
        public string Surname;
        public string Forenames;
        public string Postcode;
        public string RecruitmentOfficer;
        public string Sites;
    }
}
