using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Wolfram.Alpha.Models.Warnings;
using System.Linq;

namespace Wolfram.Alpha.Converters
{
    internal class WarningConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => throw new NotImplementedException();

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Children().Count() == 1 && token.Children().First().First().Type == JTokenType.String)
            {
                return token.ToObject<DelimitersWarning>();
            }
            return token.ToObject(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

        public override bool CanWrite => false;
    }
}
