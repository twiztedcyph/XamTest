using PropertyChanged;
using SQLite;

namespace FCA.Models
{
    [AddINotifyPropertyChangedInterface]
    [Table("DBSite")]
    public class DBSite
    {
        [PrimaryKey]
        public string Site { get; set; }
        public string Description { get; set; }
    }
}
