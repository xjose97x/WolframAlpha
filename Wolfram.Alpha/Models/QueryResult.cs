using Newtonsoft.Json;
using System.Collections.Generic;
using Wolfram.Alpha.Converters;

namespace Wolfram.Alpha.Models
{
    public class QueryResult
    {
        public bool Success { get; set; }
        [JsonConverter(typeof(ErrorConverter))]
        public Error Error { get; set; }
        public string DataTypes { get; set; }
        public int? Timedout { get; set; }
        public string TimedoutPods { get; set; }
        public float Timing { get; set; }
        public float ParseTiming { get; set; }
        public bool ParseTimedout { get; set; }
        public string Recalculate { get; set; }
        public string Id { get; set; }
        public string Host { get; set; }
        public int Server { get; set; }
        public string Related { get; set; }
        public float Version { get; set; }
        public List<Pod> Pods { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<Assumption>))]
        public List<Assumption> Assumptions { get; set; }
        public List<Source> Sources { get; set; }
        public List<Tip> Tips { get; set; }
    }
}
