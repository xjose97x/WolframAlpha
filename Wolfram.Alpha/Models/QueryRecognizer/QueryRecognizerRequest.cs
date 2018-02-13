namespace Wolfram.Alpha.Models.QueryRecognizer
{
    public class QueryRecognizerRequest
    {
        public string Input { get; set; }
        public string Mode { get; set; } = QueryRecognizerMode.Default;
    }
}
