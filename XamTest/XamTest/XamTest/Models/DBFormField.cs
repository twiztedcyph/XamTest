using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamTest.Models
{
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
