using Newtonsoft.Json;

namespace Wolfram.Alpha.Models
{
    public class Value
    {
        public string Name { get; set; }
        [JsonProperty("desc")]
        public string Description { get; set; }
        public string Input { get; set; }
    }
}
