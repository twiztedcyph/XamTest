// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Pellcomp.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class OrganisationDTO
    {
        /// <summary>
        /// Initializes a new instance of the OrganisationDTO class.
        /// </summary>
        public OrganisationDTO()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the OrganisationDTO class.
        /// </summary>
        public OrganisationDTO(int? employeeCount = default(int?), string accountingSystemID = default(string), string additionalID = default(string), string allowMarketing = default(string), string allowedContactMethods = default(string), string code = default(string), string company = default(string), string companyType = default(string), string edsERN = default(string), string email = default(string), string invoiceEmail = default(string), string invoiceFax = default(string), string invoiceName = default(string), string invoicePhone = default(string), string placementName = default(string), string preferredContactMethod = default(string), string referralSource = default(string), string roles = default(string), string status = default(string), string sysStatus = default(string), string telephone = default(string), string username = default(string), string vATRegNo = default(string), string websiteURL = default(string), AddressDTO address = default(AddressDTO), AddressDTO invoiceAddress = default(AddressDTO), OfficerDTO mainContact = default(OfficerDTO), IList<OfficerDTO> contacts = default(IList<OfficerDTO>))
        {
            EmployeeCount = employeeCount;
            AccountingSystemID = accountingSystemID;
            AdditionalID = additionalID;
            AllowMarketing = allowMarketing;
            AllowedContactMethods = allowedContactMethods;
            Code = code;
            Company = company;
            CompanyType = companyType;
            EdsERN = edsERN;
            Email = email;
            InvoiceEmail = invoiceEmail;
            InvoiceFax = invoiceFax;
            InvoiceName = invoiceName;
            InvoicePhone = invoicePhone;
            PlacementName = placementName;
            PreferredContactMethod = preferredContactMethod;
            ReferralSource = referralSource;
            Roles = roles;
            Status = status;
            SysStatus = sysStatus;
            Telephone = telephone;
            Username = username;
            VATRegNo = vATRegNo;
            WebsiteURL = websiteURL;
            Address = address;
            InvoiceAddress = invoiceAddress;
            MainContact = mainContact;
            Contacts = contacts;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EmployeeCount")]
        public int? EmployeeCount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AccountingSystemID")]
        public string AccountingSystemID { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AdditionalID")]
        public string AdditionalID { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AllowMarketing")]
        public string AllowMarketing { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AllowedContactMethods")]
        public string AllowedContactMethods { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Code")]
        public string Code { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Company")]
        public string Company { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CompanyType")]
        public string CompanyType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EdsERN")]
        public string EdsERN { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "InvoiceEmail")]
        public string InvoiceEmail { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "InvoiceFax")]
        public string InvoiceFax { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "InvoiceName")]
        public string InvoiceName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "InvoicePhone")]
        public string InvoicePhone { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PlacementName")]
        public string PlacementName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PreferredContactMethod")]
        public string PreferredContactMethod { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ReferralSource")]
        public string ReferralSource { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Roles")]
        public string Roles { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "SysStatus")]
        public string SysStatus { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Telephone")]
        public string Telephone { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Username")]
        public string Username { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "VATRegNo")]
        public string VATRegNo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "WebsiteURL")]
        public string WebsiteURL { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Address")]
        public AddressDTO Address { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "InvoiceAddress")]
        public AddressDTO InvoiceAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MainContact")]
        public OfficerDTO MainContact { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Contacts")]
        public IList<OfficerDTO> Contacts { get; set; }

    }
}
