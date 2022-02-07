using Newtonsoft.Json;

namespace TransparentData.Models.TransparentData
{

    public partial class PdfElement
    {
        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public PdfParams Params { get; set; }

        [JsonProperty("meta")]
        public object Meta { get; set; }

        [JsonProperty("result")]
        public PdfResult PdfResult { get; set; }
    }

    public partial class PdfParams
    {
        [JsonProperty("nip")]
        public string Nip { get; set; }
    }

    public partial class PdfResult
    {
        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("added")]
        public string Added { get; set; }
    }

}




