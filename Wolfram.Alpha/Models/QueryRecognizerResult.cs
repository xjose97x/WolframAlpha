namespace Wolfram.Alpha.Models
{
    public class QueryRecognizerResult
    {
        public bool Accepted { get; set; }
        public float Timing { get; set; }
        public string Domain { get; set; }
        public int ResultSignificanceScore { get; set; }
    }
}
