using SQLite.Net.Attributes;

namespace FCA.Models
{
    public class DBSite
    {
        [PrimaryKey]
        public string Site { get; set; }
        public string Description { get; set; }
    }
}
