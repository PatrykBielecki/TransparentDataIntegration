using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransparentData.Models
{
    public class ResponceFromAdd
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("ident")]
        public string Ident { get; set; }
    }
}
