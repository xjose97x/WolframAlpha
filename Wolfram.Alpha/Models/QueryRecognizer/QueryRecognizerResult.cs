using System;
using System.Collections.Generic;

namespace Wolfram.Alpha.Models.QueryRecognizer
{
    [Serializable]
    public class QueryRecognizerResult
    {
        public float Version { get; set; }
        public string SpellingCorrection { get; set; }
        public int BuildNumber { get; set; }
        public List<Query> Query { get; set; }
    }
}
