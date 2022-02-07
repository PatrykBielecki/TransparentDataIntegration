using Newtonsoft.Json;

namespace TransparentData.Models.Webcon
{
    public class Responce
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("instanceNumber")]
        public string InstanceNumber { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
