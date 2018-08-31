using PropertyChanged;
using SQLite;
using System;

namespace FCA.Models
{
    [AddINotifyPropertyChangedInterface]
    [Table("DBApplicant")]
    public class DBApplicant
    {
        [PrimaryKey]
        public string RecGUID { get; set; }
        public string ApIdent { get; set; }
        public string Forenames { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public DateTime? DOB { get; set; }
        public string NINumber { get; set; }
        public string PostCode { get; set; }
        public string Status { get; set; }
        public string SubStatus { get; set; }
        public string Employer { get; set; }
        public string EmployerName { get; set; }
        public string QualPlan { get; set; }
        public string Site { get; set; }
        public string ULN { get; set; }
        public string RecruitmentOfficer { get; set; }
        public DateTime Downloaded { get; set; }
        public DateTime LastUsed { get; set; }

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

        [Ignore]
        public bool HasNINumber
        {
            get { return !string.IsNullOrWhiteSpace(NINumber); }
        }

        [Ignore]
        public bool HasPostCode
        {
            get { return !string.IsNullOrWhiteSpace(PostCode); }
        }

        [Ignore]
        public bool HasStatus
        {
            get { return !string.IsNullOrWhiteSpace(Status); }
        }

        [Ignore]
        public bool HasSubStatus
        {
            get { return !string.IsNullOrWhiteSpace(SubStatus); }
        }

        [Ignore]
        public bool HasEmployer
        {
            get { return !string.IsNullOrWhiteSpace(Employer); }
        }
    }
}
