using SQLite;
using System.ComponentModel;

namespace FCA.Models
{
    [Table("DBCustomFormQuestion")]
    public class DBCustomFormQuestion : BaseDbItem
    {
        private string _formID;
        [PrimaryKey]
        public string FormID
        {
            get { return _formID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_formID) || !_formID.Equals(value))
                {
                    _formID = value;
                    OnPropertyChanged(nameof(FormID));
                }
            }
        }

        private string _lineID;
        public string LineID
        {
            get { return _lineID; }
            set
            {
                if (string.IsNullOrWhiteSpace(_lineID) || !_lineID.Equals(value))
                {
                    _lineID = value;
                    OnPropertyChanged(nameof(LineID));
                }
            }
        }

        private string _type;
        public string Type
        {
            get { return _type; ; }
            set
            {
                if (string.IsNullOrWhiteSpace(_type) || !_type.Equals(value))
                {
                    _type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                if (string.IsNullOrWhiteSpace(_text) || !_text.Equals(value))
                {
                    _text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        private int _sequence; 
        public int Sequence
        {
            get { return _sequence; }
            set
            {
                if (!_sequence.Equals(value))
                {
                    _sequence = value;
                    OnPropertyChanged(nameof(Sequence));
                }
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                if (string.IsNullOrWhiteSpace(_status) || !_status.Equals(value))
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        private string _layout;
        public string Layout
        {
            get { return _layout; }
            set
            {
                if (string.IsNullOrWhiteSpace(_layout) || !_layout.Equals(value))
                {
                    _layout = value;
                    OnPropertyChanged(nameof(Layout));
                }
            }
        }

        private string _importFieldName;
        public string ImportFieldName
        {
            get { return _importFieldName; }
            set
            {
                if (string.IsNullOrWhiteSpace(_importFieldName) || !_importFieldName.Equals(value))
                {
                    _importFieldName = value;
                    OnPropertyChanged(nameof(ImportFieldName));
                }
            }
        }

        private string _importFieldType;
        public string ImportFieldType
        {
            get { return _importFieldType; }
            set
            {
                if (string.IsNullOrWhiteSpace(_importFieldType) || !_importFieldType.Equals(value))
                {
                    _importFieldType = value;
                    OnPropertyChanged(nameof(ImportFieldType));
                }
            }
        }

        private string _helpText;
        public string HelpText
        {
            get { return _helpText; }
            set
            {
                if (string.IsNullOrWhiteSpace(_helpText) || !_helpText.Equals(value))
                {
                    _helpText = value;
                    OnPropertyChanged(nameof(HelpText));
                }
            }
        }

        private string _answers;
        public string Answers
        {
            get { return _answers; }
            set
            {
                if (string.IsNullOrWhiteSpace(_answers) || !_answers.Equals(value))
                {
                    _answers = value;
                    OnPropertyChanged(nameof(Answers));
                }
            }
        }

        private string _validation;
        public string Validation
        {
            get { return _validation; }
            set
            {
                if (string.IsNullOrWhiteSpace(_validation) || !_validation.Equals(value))
                {
                    _validation = value;
                    OnPropertyChanged(nameof(Validation));
                }
            }
        }

        private bool   _mandatory;
        public bool Mandatory
        {
            get { return _mandatory; }
            set
            {
                if (!_mandatory.Equals(value))
                {
                    _mandatory = value;
                    OnPropertyChanged(nameof(Mandatory));
                }
            }
        }

        private string _mandatoryErrorMessage;
        public string MandatoryErrorMessage
        {
            get { return _mandatoryErrorMessage; }
            set
            {
                if (string.IsNullOrWhiteSpace(_mandatoryErrorMessage) || !_mandatoryErrorMessage.Equals(value))
                {
                    _mandatoryErrorMessage = value;
                    OnPropertyChanged(nameof(MandatoryErrorMessage));
                }
            }
        }

        private string _minVal;
        public string MinVal
        {
            get { return _minVal; }
            set
            {
                if (string.IsNullOrWhiteSpace(_minVal) || !_minVal.Equals(value))
                {
                    _minVal = value;
                    OnPropertyChanged(nameof(MinVal));
                }
            }
        }

        private string _maxVal;
        public string MaxVal
        {
            get { return _maxVal; }
            set
            {
                if (string.IsNullOrWhiteSpace(_maxVal) || !_maxVal.Equals(value))
                {
                    _maxVal = value;
                    OnPropertyChanged(nameof(MaxVal));
                }
            }
        }

        private string _minValueErrorMessage;
        public string MinValueErrorMessage
        {
            get { return _minValueErrorMessage; }
            set
            {
                if (string.IsNullOrWhiteSpace(_minValueErrorMessage) || !_minValueErrorMessage.Equals(value))
                {
                    _minValueErrorMessage = value;
                    OnPropertyChanged(nameof(MinValueErrorMessage));
                }
            }
        }

        private string _maxValueErrorMessage;
        public string MaxValueErrorMessage
        {
            get { return _maxValueErrorMessage; }
            set
            {
                if (string.IsNullOrWhiteSpace(_maxValueErrorMessage) || !_maxValueErrorMessage.Equals(value))
                {
                    _maxValueErrorMessage = value;
                    OnPropertyChanged(nameof(MaxValueErrorMessage));
                }
            }
        }

        private string _default;
        public string Default
        {
            get { return _default; }
            set
            {
                if (string.IsNullOrWhiteSpace(_default) || !_default.Equals(value))
                {
                    _default = value;
                    OnPropertyChanged(nameof(Default));
                }
            }
        }
    }
}
