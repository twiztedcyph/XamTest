// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Pellcomp.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class LearnerSearchFilter
    {
        /// <summary>
        /// Initializes a new instance of the LearnerSearchFilter class.
        /// </summary>
        public LearnerSearchFilter()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the LearnerSearchFilter class.
        /// </summary>
        public LearnerSearchFilter(string firstname = default(string), string surname = default(string), string postcode = default(string))
        {
            Firstname = firstname;
            Surname = surname;
            Postcode = postcode;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Firstname")]
        public string Firstname { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Surname")]
        public string Surname { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Postcode")]
        public string Postcode { get; set; }

    }
}
