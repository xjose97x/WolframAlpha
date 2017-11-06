using System.Collections.Generic;

namespace Wolfram.Alpha.Models.Warnings
{
    public class ReinterpretWarning
    {
        public string Text { get; set; }
        public string New { get; set; }
        public List<Alternative> Alternatives { get; set; }
    }
}
