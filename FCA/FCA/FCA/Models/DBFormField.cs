using PropertyChanged;
using SQLite;

namespace FCA.Models
{
    [AddINotifyPropertyChangedInterface]
    [Table("DBFormField")]
    public class DBFormField
    {
        [PrimaryKey]
        public string RecGUID { get; set; }
        public string FormInstanceID { get; set; }
        public string FormType { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public string FieldValue{ get; set; }
    }
}
