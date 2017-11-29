using System;
using Newtonsoft.Json;

namespace Wolfram.Alpha.Models
{
    [Serializable]
    public class FutureTopic
    {
        public string Topic { get; set; }
        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}
