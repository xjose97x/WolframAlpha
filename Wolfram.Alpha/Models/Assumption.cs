using System.Collections.Generic;

namespace Wolfram.Alpha.Models
{
    public class Assumption
    {
        public string Type { get; set; }
        public string Word { get; set; }
        public string Template { get; set; }
        public List<Value> Values { get; set; }
    }
}
