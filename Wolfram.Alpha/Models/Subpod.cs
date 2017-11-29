using System;
using Newtonsoft.Json;
using Wolfram.Alpha.Models.Output;

namespace Wolfram.Alpha.Models
{
    [Serializable]
    public class SubPod
    {
        public string Title { get; set; }
        public string ImageSource { get; set; }
        [JsonProperty("img")]
        public Image Image { get; set; }
        public string Plaintext { get; set; }
        public string Minput { get; set; }
    }
}
