using System;

namespace Wolfram.Alpha.Attributes
{
    internal class QueryStringAttribute : Attribute
    {
        public string Name { get; set; }
        public QueryStringAttribute(string name)
        {
            Name = name;
        }
    }
}
