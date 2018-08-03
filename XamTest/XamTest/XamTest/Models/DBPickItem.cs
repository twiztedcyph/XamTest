using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamTest.Models
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
