using Pellcomp.Vs.Mobile.FormCaptureApp.lib;
using SQLite.Net.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCA.Models
{
    public class DBOfficer
    {
        [PrimaryKey]
        public string Officer { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Roles { get; set; }

        public static async Task<List<DBOfficer>> getOfficerByType(string type)
        {
            return new List<DBOfficer>();// await App.DB.GetOfficers(type);
        }

        public static string getOfficerTypeCode(string fieldName)
        {
            if (fieldName.Equals(uImportConsts.MAIN_OFFICER.ToUpper()))
            {
                return "Z";
            }
            else if (fieldName.Equals(uImportConsts.Training_Officer.ToUpper()) || fieldName.Equals(uImportApplicantConsts.APP_OFF_TRAIN))
            {
                return "T";
            }
            else if (fieldName.Equals(uImportConsts.Careers_Officer.ToUpper()))
            {
                return "C";
            }
            else if (fieldName.Equals(uImportConsts.Placement_Officer.ToUpper()))
            {
                return "P";
            }
            else if (fieldName.Equals(uImportConsts.Mentor_Officer.ToUpper()) || fieldName.Equals(uImportApplicantConsts.APP_MENTOR))
            {
                return "M";
            }
            else if (fieldName.StartsWith(uImportConsts.AIMASSESSOR.ToUpper()))
            {
                return "A";
            }
            else if (fieldName.StartsWith(uImportConsts.AIMIV.ToUpper()))
            {
                return "I";
            }
            else if (fieldName.StartsWith(uImportConsts.AIMEV.ToUpper()))
            {
                return "E";
            }
            else if (fieldName.Equals(uImportApplicantConsts.APP_RECRUITED_BY))
            {
                return "Y";
            }

            return string.Empty;
        }
    }
}
