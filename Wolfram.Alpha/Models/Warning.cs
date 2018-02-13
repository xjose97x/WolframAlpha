using System;
using Wolfram.Alpha.Models.Warnings;

namespace Wolfram.Alpha.Models
{
    [Serializable]
    public class Warning
    {
        public TranslationWarning Translation { get; set; }
        public DelimitersWarning Delimiters { get; set; }
        public ReinterpretWarning Reinterpret { get; set; }
        public SpellCheckWarning SpellCheck { get; set; }
    }
}
