using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Models
{
    public class DBCustomFormQuestion
    {
        public string FormID { get; set; }

        public string LineID { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }

        public int Sequence { get; set; }

        public string Status { get; set; }

        public string Layout { get; set; }

        public string ImportFieldName { get; set; }

        public string ImportFieldType { get; set; }

        public string HelpText { get; set; }

        public string Answers { get; set; }

        public string Validation { get; set; }

        public bool Mandatory { get; set; }

        public string MandatoryErrorMessage { get; set; }

        public string MinVal { get; set; }

        public string MinValueErrorMessage { get; set; }

        public string MaxVal { get; set; }

        public string MaxValueErrorMessage { get; set; }

        public string Default { get; set; }        
    }
}
