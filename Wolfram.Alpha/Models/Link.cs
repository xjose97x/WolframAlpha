using System;

namespace Wolfram.Alpha.Models
{
    [Serializable]
    public class Link
    {
        public string Url { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
