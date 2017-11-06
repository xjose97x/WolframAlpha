using Newtonsoft.Json;

namespace Wolfram.Alpha.Models
{
    public class WolframResult
    {
        [JsonProperty("queryresult")]
        public QueryResult Result { get; set; }
    }
}
