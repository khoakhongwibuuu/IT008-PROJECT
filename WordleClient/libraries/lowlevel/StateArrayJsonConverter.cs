using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WordleClient.libraries.lowlevel
{
    public sealed class StateArrayJsonConverter : JsonConverter<StateArray>
    {
        public override StateArray Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException("StateArray must be an object");

            byte[]? data = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    break;

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string prop = reader.GetString()!;
                    reader.Read();

                    if (prop == "Data")
                    {
                        data = JsonSerializer.Deserialize<byte[]>(ref reader, options);
                    }
                    else
                    {
                        reader.Skip();
                    }
                }
            }

            if (data == null)
                throw new JsonException("Missing Data for StateArray");

            StateArray sa = new StateArray(data.Length);
            for (int i = 0; i < data.Length; i++)
                sa.Set(i, (TriState)data[i]);

            return sa;
        }

        public override void Write(
            Utf8JsonWriter writer,
            StateArray value,
            JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Data");
            JsonSerializer.Serialize(writer, value.Data, options);
            writer.WriteEndObject();
        }
    }
}
