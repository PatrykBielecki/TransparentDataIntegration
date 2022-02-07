using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentData.Models.TransparentData
{
    public partial class KrsElement
    {
        [JsonProperty("task_id")]
        public long TaskId { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public Params Params { get; set; }

        [JsonProperty("meta")]
        public object Meta { get; set; }

        [JsonProperty("result")]
        public KrsResult Result { get; set; }
    }

    public partial class KrsParams
    {
        [JsonProperty("nip")]
        public string Nip { get; set; }

        [JsonProperty("includeCEIDGData")]
        public bool IncludeCeidgData { get; set; }

        [JsonProperty("additional-info")]
        public bool AdditionalInfo { get; set; }
    }

    public partial class KrsResult
    {
        [JsonProperty("data_acquisition_date")]
        public DateTimeOffset DataAcquisitionDate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("legal_form")]
        public string LegalForm { get; set; }

        [JsonProperty("krs")]
        public string Krs { get; set; }

        [JsonProperty("nip")]
        public string Nip { get; set; }

        [JsonProperty("regon")]
        public string Regon { get; set; }

        [JsonProperty("company_status")]
        public string CompanyStatus { get; set; }

        [JsonProperty("address")]
        public KrsAddress Address { get; set; }

        [JsonProperty("equity")]
        public string Equity { get; set; }

        [JsonProperty("stock")]
        public KrsStock Stock { get; set; }

        [JsonProperty("incorporation")]
        public string Incorporation { get; set; }

    }

    public partial class KrsAddress
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("post")]
        public string Post { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public partial class KrsRelation
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("relation")]
        public string RelationRelation { get; set; }

        [JsonProperty("relation_extra_info")]
        public string RelationExtraInfo { get; set; }

        [JsonProperty("shares", NullValueHandling = NullValueHandling.Ignore)]
        public KrsStock Shares { get; set; }

        [JsonProperty("ident")]
        public KrsIdent Ident { get; set; }
    }

    public partial class KrsIdent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class KrsStock
    {
        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}


