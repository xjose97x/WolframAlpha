using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Wolfram.Alpha.Converters;

namespace Wolfram.Alpha.Models
{
    [Serializable]
    public class Assumption
    {
        public string Type { get; set; }
        public string Word { get; set; }
        public string Template { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<Value>))]
        public List<Value> Values { get; set; }

        public string BuildTemplate()
        {

            string pattern = @"\${(.*?)\}";
            var regex = new Regex(pattern, RegexOptions.None);
            string builtTemplate = Template;
            while (regex.IsMatch(builtTemplate))
            {
                var result = regex.Match(builtTemplate);
                var templateValue = result.Value.Remove(0, 2);
                templateValue = templateValue.Remove(templateValue.Length - 1);
                var replaceIndex = (int)Char.GetNumericValue(templateValue.Last()) - 1;
                templateValue = templateValue.Remove(templateValue.Length - 1);
                var replaceType = templateValue;

                var replaceValueObject = Values[replaceIndex];

                var properties = replaceValueObject.GetType().GetProperties();
                var replaceValue = properties.FirstOrDefault(p =>
                {
                    var name = p.Name;
                    var attribute = p.GetCustomAttribute<JsonPropertyAttribute>(inherit: true);
                    if (attribute != null)
                    {
                        name = attribute.PropertyName;
                    }
                    return name.ToLower() == replaceType;
                });
                var stringReplaceValue = replaceValue?.GetValue(replaceValueObject, null).ToString();
                builtTemplate = builtTemplate.Replace(result.Value, stringReplaceValue);
            }
            return builtTemplate;
        }
    }
}
