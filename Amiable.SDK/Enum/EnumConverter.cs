using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Amiable.SDK.Enum
{
    public class EnumConverter<T> : JsonConverter<T>
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return (T)System.Enum.Parse(typeof(T),reader.GetString(),true);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString().ToLower());
        }
    }
}
