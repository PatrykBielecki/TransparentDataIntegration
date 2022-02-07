using Newtonsoft.Json;

namespace TransparentData.Models.TransparentData
{

    public partial class WhitelistElement
    {
        [JsonProperty("task_id")]
        public long TaskId { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public WhitelistParams WhitelistParams { get; set; }

        [JsonProperty("meta")]
        public object WhitelistMeta { get; set; }

        [JsonProperty("result")]
        public WhitelistResult WhitelistResult { get; set; }
    }

    public partial class WhitelistMeta
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }

    public partial class WhitelistParams
    {
        [JsonProperty("nip")]
        public string Nip { get; set; }

    }

    public partial class WhitelistResult
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nip")]
        public string Nip { get; set; }

        [JsonProperty("regon")]
        public string Regon { get; set; }

        [JsonProperty("krs")]
        public string Krs { get; set; }

        [JsonProperty("pesel")]
        public object Pesel { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("vat_status")]
        public string VatStatus { get; set; }

        [JsonProperty("working_address")]
        public string WorkingAddress { get; set; }

        [JsonProperty("residence_address")]
        public object ResidenceAddress { get; set; }

        [JsonProperty("revenue_agency")]
        public WhitelistRevenueAgency WhitelistRevenueAgency { get; set; }
    }

    public partial class WhitelistRevenueAgency
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("adress")]
        public string Adress { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }
    }
}




