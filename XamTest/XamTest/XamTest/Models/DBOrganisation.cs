using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamTest.Models
{
    public class DBOrganisation
    {
        [PrimaryKey]
        public string RecGUID { get; set; }
        public string Place { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string EdsERN { get; set; }        
        public string Roles { get; set; }
        public string Status { get; set; }
        public string SysStatus { get; set; }
        public string SyncStatus { get; set; }
        public string MainContactCode { get; set; }
        public string MainContactSurname { get; set; }
        public string MainContactFirstname { get; set; }
        public string MainContactEmail { get; set; }
        public string MainContactPhone { get; set; }
        public string MainContactMobile { get; set; }
        public string HeadOffice { get; set; }
        public string AllowedContactMethods { get; set; }
        public string PreferredContactMethod { get; set; }
    }
}
