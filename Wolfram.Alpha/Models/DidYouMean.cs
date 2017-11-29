using System;
using Newtonsoft.Json;

namespace Wolfram.Alpha.Models
{
    [Serializable]
    public class DidYouMean
    {
        [JsonProperty("val")]
        public string Value { get; set; }

        public string Level { get; set; }
        public float Score { get; set; }
    }
}
