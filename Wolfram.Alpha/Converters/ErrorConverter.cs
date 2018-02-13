using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Wolfram.Alpha.Converters
{
    internal class ErrorConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => throw new NotImplementedException();

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            return token.Type == JTokenType.Boolean ? null : token.ToObject(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
}
