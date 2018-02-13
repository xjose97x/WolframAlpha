using Wolfram.Alpha.Attributes;

namespace Wolfram.Alpha.Models.QueryRecognizer
{
    public class QueryRecognizerRequest
    {
        public QueryRecognizerRequest(string input)
        {
            Input = input;
        }

        [QueryString("i")]
        public string Input { get; set; }
        public string Mode { get; set; } = QueryRecognizerMode.Default;
        public string Output { get; } = "json";
    }
}
