using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Wolfram.Alpha.Converters;

namespace Wolfram.Alpha.Models
{
    [Serializable]
    public class Assumption
    {
        public string Type { get; set; }
        public string Word { get; set; }
        public string Template { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<Value>))]
        public List<Value> Values { get; set; }
    }
}
