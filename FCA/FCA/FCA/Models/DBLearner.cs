using System;
using System.Text;
using Pellcomp.Vs.Mobile.FormCaptureApp.lib;
using PropertyChanged;
using SQLite;

namespace FCA.Models
{
    [AddINotifyPropertyChangedInterface]
    [Table("DBLearner")]
    public class DBLearner
    {
        [PrimaryKey]
        public string Ident { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime? DOB { get; set; }
        public string Sex { get; set; }
        public string NINumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string ULIN { get; set; }
        public string ULN { get; set; }
        public string EmployerCode { get; set; }
        public string EmployerName { get; set; }
        public DateTime? TrainingStart { get; set; }
        public DateTime? TrainingExpEnd { get; set; }
        public DateTime? TrainingEnd { get; set; }
        public DateTime? Downloaded { get; set; }

        [Ignore]
        public string DisplayName => $"{Surname}, {Firstname}";

        [Ignore]
        public string DisplaySex => SharedListLoad.SEX[Sex];

        [Ignore]
        public string DisplayAddress
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                if (!string.IsNullOrWhiteSpace(Address1))
                    builder.Append(Address1 + Environment.NewLine);
                if (!string.IsNullOrWhiteSpace(Address2))
                    builder.Append(Address2 + Environment.NewLine);
                if (!string.IsNullOrWhiteSpace(Address3))
                    builder.Append(Address3 + Environment.NewLine);
                if (!string.IsNullOrWhiteSpace(Address4))
                    builder.Append(Address4 + Environment.NewLine);
                if (!string.IsNullOrWhiteSpace(Postcode))
                    builder.Append(Postcode);
                return builder.ToString();
            }
        }
        
        [Ignore]
        public bool HasPhone { get { return !string.IsNullOrWhiteSpace(Phone); } }

        [Ignore]
        public bool HasMobile { get { return !string.IsNullOrWhiteSpace(MobilePhone); } }

        [Ignore]
        public bool HasTrainingEnd { get { return TrainingEnd.HasValue; } }
    }
}
