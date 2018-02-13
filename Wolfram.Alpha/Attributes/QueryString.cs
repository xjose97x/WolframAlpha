using System;

namespace Wolfram.Alpha.Attributes
{
    internal class QueryString : Attribute
    {
        public string Name { get; set; }
        public QueryString(string name)
        {
            Name = name;
        }
    }
}
