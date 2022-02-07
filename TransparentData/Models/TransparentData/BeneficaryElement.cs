using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentData.Models.TransparentData
{
    public partial class BeneficaryElement
    {
        [JsonProperty("task_id")]
        public long TaskId { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public BeneficaryParams Params { get; set; }

        [JsonProperty("meta")]
        public object Meta { get; set; }

        [JsonProperty("result")]
        public BeneficaryResult BeneficaryResult { get; set; }
    }

    public partial class BeneficaryParams
    {
        [JsonProperty("nip")]
        public long Nip { get; set; }
    }

    public partial class BeneficaryResult
    {
        [JsonProperty("beneficiaries")]
        public List<Beneficiary> Beneficiaries { get; set; }
    }

    public partial class Beneficiary
    {
        [JsonProperty("pesel")]
        public string Pesel { get; set; }

        [JsonProperty("percentage")]
        public string Percentage { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
