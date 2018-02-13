using System;

namespace Wolfram.Alpha.Models.QueryRecognizer
{
    [Serializable]
    public class Query
    {
        public bool Accepted { get; set; }
        public float Timing { get; set; }
        public string Domain { get; set; }
        public int ResultSignificanceScore { get; set; }
        public object SummaryBox { get; set; }
    }
}
