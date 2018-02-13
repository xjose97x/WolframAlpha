using System;
using Newtonsoft.Json;
using Wolfram.Alpha.Models.InstantCalculators;

namespace Wolfram.Alpha.Models.QueryRecognizer
{
    [Serializable]
    public class Query
    {
        [JsonProperty("i")]
        public string Input { get; set; }
        public bool Accepted { get; set; }
        public float Timing { get; set; }
        public string Domain { get; set; }
        public int ResultSignificanceScore { get; set; }
        public object SummaryBox { get; set; }
        public InstantCalculatorsFormula Formula { get; set; }

    }
}
