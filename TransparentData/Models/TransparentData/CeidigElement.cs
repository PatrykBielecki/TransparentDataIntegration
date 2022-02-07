using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentData.Models.TransparentData
{
    public partial class CeidigElement
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("task_id")]
        public long TaskId { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public CeidigParams CeidigParams { get; set; }

        [JsonProperty("meta")]
        public object Meta { get; set; }

        [JsonProperty("result")]
        public CeidigResult CeidigResult { get; set; }
    }

    public partial class CeidigParams
    {
        [JsonProperty("nip")]
        public string Nip { get; set; }
    }

    public partial class CeidigResult
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("nip")]
        public string Nip { get; set; }

        [JsonProperty("regon")]
        public string Regon { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("company_status")]
        public string CompanyStatus { get; set; }

        [JsonProperty("beginning_date")]
        public string BeginningDate { get; set; }

        [JsonProperty("suspended_from_date")]
        public object SuspendedFromDate { get; set; }

        [JsonProperty("suspended_to_date")]
        public object SuspendedToDate { get; set; }

        [JsonProperty("ending_date")]
        public object EndingDate { get; set; }

        [JsonProperty("deletion_legal_basis")]
        public object DeletionLegalBasis { get; set; }

        [JsonProperty("legal_basis_details")]
        public object LegalBasisDetails { get; set; }

        [JsonProperty("cancellation")]
        public object Cancellation { get; set; }

        [JsonProperty("has_community_of_goods")]
        public string HasCommunityOfGoods { get; set; }

        [JsonProperty("main_pkd")]
        public string MainPkd { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("phone")]
        public object Phone { get; set; }

        [JsonProperty("fax")]
        public object Fax { get; set; }

        [JsonProperty("www")]
        public object Www { get; set; }

        [JsonProperty("email")]
        public object Email { get; set; }

        [JsonProperty("main_address")]
        public CeidigAddress MainAddress { get; set; }

        [JsonProperty("postal_address")]
        public CeidigAddress PostalAddress { get; set; }

        [JsonProperty("in_civil_partnership")]
        public long InCivilPartnership { get; set; }

        [JsonProperty("civil_partnership_details")]
        public List<object> CivilPartnershipDetails { get; set; }

        [JsonProperty("permissions")]
        public List<object> Permissions { get; set; }

        [JsonProperty("restrictions")]
        public List<object> Restrictions { get; set; }

        [JsonProperty("agents")]
        public List<object> Agents { get; set; }

        [JsonProperty("extra_addresses")]
        public List<CeidigAddress> ExtraAddresses { get; set; }

        [JsonProperty("date_of_cessation_of_activity")]
        public object DateOfCessationOfActivity { get; set; }
    }

    public partial class CeidigAddress
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("local")]
        public long? Local { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("post")]
        public string Post { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("commune", NullValueHandling = NullValueHandling.Ignore)]
        public string Commune { get; set; }
    }
}
