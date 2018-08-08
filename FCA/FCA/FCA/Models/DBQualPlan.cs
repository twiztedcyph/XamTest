using PropertyChanged;
using SQLite;
using System.Collections.Generic;

namespace FCA.Models
{
    [AddINotifyPropertyChangedInterface]
    [Table("DBQualPlan")]
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

        [Ignore]
        public List<DBQualPlanDet> Qualifications { get; set; } = new List<DBQualPlanDet>();
    }
}
