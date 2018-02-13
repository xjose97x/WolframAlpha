using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Wolfram.Alpha.Models.InstantCalculators;

namespace Wolfram.Alpha.Converters
{
    internal class InstantCalculatorsValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => (objectType == typeof(InstantCalculatorsValue));

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (!token.Children().Any())
            {
                var value = new InstantCalculatorsValue
                {
                    Description = token.Value<string>(),
                    Name = token.Value<string>()
                };
                return new List<InstantCalculatorsValue> { value };
            }
            return token.Type == JTokenType.Array ? token.ToObject<List<InstantCalculatorsValue>>() : new List<InstantCalculatorsValue> { token.ToObject<InstantCalculatorsValue>() };
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
}
