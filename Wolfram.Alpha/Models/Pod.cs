using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Wolfram.Alpha.Converters;

namespace Wolfram.Alpha.Models
{
    [Serializable]
    public class Pod
    {
        public string Title { get; set; }
        public string Scanner { get; set; }
        public string Id { get; set; }
        public int Position { get; set; }
        public bool Error { get; set; }
        public string Async { get; set; }
        public bool Primary { get; set; }
        public List<SubPod> SubPods { get; set; }
        public List<State> States { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<Info>))]
        public List<Info> Infos { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<Sound>))]
        public List<Sound> Sounds { get; set; }
        public Generalization Generalization { get; set; }
    }
}
