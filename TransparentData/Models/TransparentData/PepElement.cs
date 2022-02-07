using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentData.Models.TransparentData
{
    public partial class PepElement
    {
        [JsonProperty("task_id")]
        public long TaskId { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public PepParams PepParams { get; set; }

        [JsonProperty("meta")]
        public object Meta { get; set; }

        [JsonProperty("result")]
        public PepResult PepResult { get; set; }
    }

    public partial class PepParams
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class PepResult
    {
        [JsonProperty("list_name")]
        public string ListName { get; set; }

        [JsonProperty("list_details")]
        public string ListDetails { get; set; }
    }


}
