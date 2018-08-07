using SQLite;
using System;

namespace FCA.Models
{
    public class DBApplicant : BaseDbItem
    {
        private string _recGUID;
        [PrimaryKey]
        public string RecGUID
        {
            get { return _FormID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_FormID) || !_FormID.Equals(value))
                {
                    _FormID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

        private string _apIdent;
        public string ApIdent
        {
            get { return _FormID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_FormID) || !_FormID.Equals(value))
                {
                    _FormID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

        private string _forenames;
        public string Forenames
        {
            get { return _FormID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_FormID) || !_FormID.Equals(value))
                {
                    _FormID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _FormID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_FormID) || !_FormID.Equals(value))
                {
                    _FormID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

        private string _sex;
        public string Sex
        {
            get { return _FormID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_FormID) || !_FormID.Equals(value))
                {
                    _FormID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

        private DateTime? _dOB;
        public DateTime? DOB
        {
            get { return _FormID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_FormID) || !_FormID.Equals(value))
                {
                    _FormID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

        private string _nINumber;
        public string NINumber
        {
            get { return _FormID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_FormID) || !_FormID.Equals(value))
                {
                    _FormID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

        private string _postCode;
        public string PostCode
        {
            get { return _FormID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_FormID) || !_FormID.Equals(value))
                {
                    _FormID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

        private string _status;
        public string Status
        {
            get { return _FormID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_FormID) || !_FormID.Equals(value))
                {
                    _FormID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

        private string _subStatus;
        public string SubStatus
        {
            get { return _FormID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_FormID) || !_FormID.Equals(value))
                {
                    _FormID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

        private string _employer;
        public string Employer
        {
            get { return _FormID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_FormID) || !_FormID.Equals(value))
                {
                    _FormID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

        private string _employerName;
        public string EmployerName
        {
            get { return _FormID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_FormID) || !_FormID.Equals(value))
                {
                    _FormID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

        private string _qualPlan;
        public string QualPlan
        {
            get { return _FormID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_FormID) || !_FormID.Equals(value))
                {
                    _FormID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

        private string _site;
        public string Site
        {
            get { return _FormID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_FormID) || !_FormID.Equals(value))
                {
                    _FormID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

        private string _uLN;
        public string ULN
        {
            get { return _FormID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_FormID) || !_FormID.Equals(value))
                {
                    _FormID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

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
