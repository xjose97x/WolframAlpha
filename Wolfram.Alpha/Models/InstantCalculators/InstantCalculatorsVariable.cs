using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Wolfram.Alpha.Converters;

namespace Wolfram.Alpha.Models.InstantCalculators
{
    [Serializable]
    public class InstantCalculatorsVariable
    {
        public string Name { get; set; }
        [JsonProperty("desc")]
        public string Description { get; set; }

        public int Current { get; set; }
        public int Count { get; set; }

        [JsonProperty("Value")]
        [JsonConverter(typeof(InstantCalculatorsValueConverter))]
        public List<InstantCalculatorsValue> Values { get; set; }
    }
}
