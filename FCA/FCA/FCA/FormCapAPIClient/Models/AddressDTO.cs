// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Pellcomp.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class AddressDTO
    {
        /// <summary>
        /// Initializes a new instance of the AddressDTO class.
        /// </summary>
        public AddressDTO()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AddressDTO class.
        /// </summary>
        public AddressDTO(string address1 = default(string), string address2 = default(string), string address3 = default(string), string address4 = default(string), string address5 = default(string), string postcode = default(string))
        {
            Address1 = address1;
            Address2 = address2;
            Address3 = address3;
            Address4 = address4;
            Address5 = address5;
            Postcode = postcode;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Address1")]
        public string Address1 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Address2")]
        public string Address2 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Address3")]
        public string Address3 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Address4")]
        public string Address4 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Address5")]
        public string Address5 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Postcode")]
        public string Postcode { get; set; }

    }
}
