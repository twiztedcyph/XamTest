using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamTest.Models
{
    public class DBSite
    {
        [PrimaryKey]
        public string Site { get; set; }
        public string Description { get; set; }
    }
}
