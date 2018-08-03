using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamTest.Models
{
    public class DBQualPlan
    {
        [PrimaryKey]
        public string RecGUID { get; set; }

        public string PlanCode { get; set; }
        public string Title { get; set; }
        public string FrameworkTitle { get; set; }

        public string FrameworkCode { get; set; }

        public string FrameworkPathway { get; set; }

        public string Sites { get; set; }

        private List<DBQualPlanDet> _qualifications;
        [Ignore]
        public List<DBQualPlanDet> Qualifications
        {
            get
            {
                if (_qualifications == null)
                    _qualifications = new List<DBQualPlanDet>();
                return _qualifications;
            }
            set
            {
                _qualifications = value;
            }
        }
        
    }
}
