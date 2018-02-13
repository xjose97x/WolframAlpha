using Wolfram.Alpha.Attributes;

namespace Wolfram.Alpha.Models.SpokenResults
{
    public class SpokenResultsRequest
    {
        public SpokenResultsRequest(string input)
        {
            Input = input;
        }

        [QueryString("i")]
        public string Input { get; set; }
        public int Timeout { get; set; } = 5;
        public string Units { get; set; } = SpokenResultsUnits.Metric;
    }
}
