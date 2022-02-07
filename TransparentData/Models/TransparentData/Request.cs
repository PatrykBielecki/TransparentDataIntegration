using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransparentData.Models
{
    public partial class Request
    {
        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }

        [JsonProperty("params", NullValueHandling = NullValueHandling.Ignore)]
        public Params Params { get; set; }
    }

    public partial class Params
    {
        [JsonProperty("nip", NullValueHandling = NullValueHandling.Ignore)]
        public string Nip { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public string Date { get; set; }

        [JsonProperty("timeout", NullValueHandling = NullValueHandling.Ignore)]
        public string Timeout { get; set; }

        [JsonProperty("includeCEIDGData", NullValueHandling = NullValueHandling.Ignore)]
        public bool IncludeCEIDGData { get; set; }

        [JsonProperty("additional-info", NullValueHandling = NullValueHandling.Ignore)]
        public bool AdditionalInfo { get; set; }

        [JsonProperty("dates-ranges", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> DatesRanges { get; set; }
    }
}
