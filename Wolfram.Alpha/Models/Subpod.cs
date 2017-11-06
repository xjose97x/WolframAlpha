using Newtonsoft.Json;
using System.Collections.Generic;
using Wolfram.Alpha.Models.Output;

namespace Wolfram.Alpha.Models
{
    public class SubPod
    {
        public string Title { get; set; }
        [JsonProperty("img")]
        public Image Image { get; set; }
        public string Plaintext { get; set; }
        public string Minput { get; set; }
    }
}
