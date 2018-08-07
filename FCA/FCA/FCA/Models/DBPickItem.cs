using SQLite.Net.Attributes;

namespace FCA.Models
{
    public class DBPickItem
    {
        [PrimaryKey]
        public string Index { get; set; }
        public string PickType { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }

    }
}
