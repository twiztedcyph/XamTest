using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamTest.Models
{
    public class ValidationResultList : List<string>
    {
        public override string ToString()
        {
            StringBuilder stringbuilder = new StringBuilder();

            foreach (string validationResult in this)
            {
                if (!string.IsNullOrEmpty(validationResult))
                {
                    stringbuilder.AppendLine(validationResult);
                }
            }

            string result = stringbuilder.ToString();
            result.Remove(result.Length - 1, 1);
            return result;
        }
    }

}
