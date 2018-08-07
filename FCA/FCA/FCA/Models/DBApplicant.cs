using SQLite;
using System;

namespace FCA.Models
{
    public class DBApplicant : BaseDbItem
    {
        private string _recGUID;
        [PrimaryKey]
        public string RecGUID
        { get; set; }

        private string _apIdent;
        public string ApIdent
        { get; set; }

        private string _forenames;
        public string Forenames
        { get; set; }

        private string _surname;
        public string Surname
        { get; set; }

        private string _sex;
        public string Sex
        { get; set; }

        private DateTime? _dOB;
        public DateTime? DOB
        { get; set; }

        private string _nINumber;
        public string NINumber
        { get; set; }

        private string _postCode;
        public string PostCode
        { get; set; }

        private string _status;
        public string Status
        { get; set; }

        private string _subStatus;
        public string SubStatus
        { get; set; }

        private string _employer;
        public string Employer
        { get; set; }

        private string _employerName;
        public string EmployerName
        { get; set; }

        private string _qualPlan;
        public string QualPlan
        { get; set; }

        private string _site;
        public string Site
        { get; set; }

        private string _uLN;
        public string ULN
        { get; set; }

        private string _recruitmentOfficer;
        public string RecruitmentOfficer
        { get; set; }

        private DateTime _downloaded;
        public DateTime Downloaded
        { get; set; }

        private DateTime _lastUsed;
        public DateTime LastUsed
        { get; set; }


        [Ignore]
        public string DisplayName
        {
            get { return $"{Surname}, {Forenames}"; }
        }

        [Ignore]
        public string DisplaySex
        {
            get 
            { 
                if (Sex.Equals("M"))
                {
                    return "Male";
                }
                else if (Sex.Equals("F"))
                {
                    return "Female";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        [Ignore]
        public string SexCode
        {
            get
            {
                if (Sex.Equals("M"))
                {
                    return "1";
                }
                else if (Sex.Equals("F"))
                {
                    return "2";
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }

}
