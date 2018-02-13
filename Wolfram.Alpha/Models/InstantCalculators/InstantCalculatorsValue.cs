using System;
using Newtonsoft.Json;

namespace Wolfram.Alpha.Models.InstantCalculators
{
    [Serializable]
    public class InstantCalculatorsValue
    {
        public string Name { get; set; }
        [JsonProperty("desc")]
        public string Description { get; set; }
    }
}
