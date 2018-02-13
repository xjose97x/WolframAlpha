using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Wolfram.Alpha.Converters;

namespace Wolfram.Alpha.Models.InstantCalculators
{
    [Serializable]
    public class InstantCalculatorsFormula
    {
        public string Name { get; set; }
        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<InstantCalculatorsVariable>))]
        public List<InstantCalculatorsVariable> Variable { get; set; }
    }
}
