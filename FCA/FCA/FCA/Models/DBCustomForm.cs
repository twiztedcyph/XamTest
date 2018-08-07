using SQLite;
using System.Collections.Generic;
using System.ComponentModel;

namespace FCA.Models
{
    [Table("DBCustomForm")]
    public class DBCustomForm : BaseDbItem
    {
        private string _FormID;
        [PrimaryKey]
        public string FormID
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

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                if (string.IsNullOrWhiteSpace(_Title) || !_Title.Equals(value))
                {
                    _Title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if (string.IsNullOrWhiteSpace(_Description) || !_Description.Equals(value))
                {
                    _Description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        private string _IsFor;
        public string IsFor
        {
            get { return _IsFor; }
            set
            {
                if (string.IsNullOrWhiteSpace(_IsFor) || !_IsFor.Equals(value))
                {
                    _IsFor = value;
                    OnPropertyChanged(nameof(IsFor));
                }
            }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set
            {
                if (string.IsNullOrWhiteSpace(_Status) || !_Status.Equals(value))
                {
                    _Status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        private string _Type;
        public string Type
        {
            get { return _Type; }
            set
            {
                if (string.IsNullOrWhiteSpace(_Type) || !_Type.Equals(value))
                {
                    _Type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }

        private string _TemplateFileID;
        public string TemplateFileID
        {
            get { return _TemplateFileID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_TemplateFileID) || !_TemplateFileID.Equals(value))
                {
                    _TemplateFileID = value;
                    OnPropertyChanged(nameof(TemplateFileID));
                }
            }
        }

        private List<DBCustomFormQuestion> _questions;
        [Ignore]
        public List<DBCustomFormQuestion> Questions
        {
            get
            {
                if (_questions == null)
                    _questions = new List<DBCustomFormQuestion>();
                return _questions;
            }
            set
            {
                if (!_questions.Equals(value))
                {
                    _questions = value;
                    OnPropertyChanged(nameof(Questions));
                }
            }
        }
    }
}
