using Newtonsoft.Json;

namespace TransparentData.Models.Webcon
{

    public partial class Attachment
    {
        [JsonProperty("name")]
        public string AttachmentName { get; set; }

        [JsonProperty("content")]
        public string AttachmentContent { get; set; }
        [JsonProperty("group")]
        public string AttachmentGroup { get; set; }
    }

}

