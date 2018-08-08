using PropertyChanged;
using SQLite;
using System.Collections.Generic;

namespace FCA.Models
{
    [AddINotifyPropertyChangedInterface]
    [Table("DBCustomForm")]
    public class DBCustomForm
    {
        [PrimaryKey]
        public string FormID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IsFor { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string TemplateFileID { get; set; }

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
                _questions = value;
            }
        }
    }
}
