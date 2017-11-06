using System;
using System.Collections.Generic;
using System.Text;

namespace Wolfram.Alpha.Models.Output
{
    public class Image
    {
        public string Src { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
