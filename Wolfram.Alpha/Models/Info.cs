using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Wolfram.Alpha.Converters;
using Wolfram.Alpha.Models.Output;

namespace Wolfram.Alpha.Models
{
    [Serializable]
    public class Info
    {
        public string Text { get; set; }
        [JsonProperty("img")]
        public Image Image { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<Link>))]
        public List<Link> Links { get; set; }
    }
}
