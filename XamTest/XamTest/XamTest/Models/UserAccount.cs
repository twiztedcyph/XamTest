using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamTest.Models
{
    public class UserAccount
    {
        [PrimaryKey]
        public string UserName { get; set; }
        public string OfficerCode { get; set; } 
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string WebServiceURL { get; set; }
        public bool LoggedIn { get; set; }
    }
}
