using Mastrosoft.CloudConvert.Models;
using Mastrosoft.CloudConvert.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mastrosoft.CloudConvert.Converters
{
    public class JobDataResponseConverter : JsonConverter<JobDataResponse>
    {
        private static Dictionary<string, Type> _typeCache = null;
        private static Type GetType(string input)
        {
            if(_typeCache == null)
            {
                Assembly
                //Dictionary<string,Type>
            }
        }

        public override bool CanConvert(Type typeToConvert) =>
            typeof(JobDataResponse).IsAssignableFrom(typeToConvert);

        public override JobDataResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException();

            var message = new JobDataResponse();
            message.Tasks = new List<TaskBase>();

            while (Expect(ref reader, JsonTokenType.StartObject, JsonTokenType.EndArray))
            {
                Expect(ref reader, JsonTokenType.PropertyName);
                var propertyName = reader.GetString();
                if (propertyName != "ev")
                    throw new JsonException();

                switch (ExpectString(ref reader))
                {
                    default:
                        throw new JsonException();
                    case "T":
                        var trade = new Trade();
                        while (Expect(ref reader, JsonTokenType.PropertyName, JsonTokenType.EndObject))
                            switch (reader.GetString())
                            {
                                default: throw new JsonException();
                                case "sym": trade.Symbol = ExpectString(ref reader); break;
                                case "p":
                                    trade.Price = ExpectDecimal(ref reader); break;
                                    ...
                }
                        message.Trades.Add(trade);
                        break;
                        ...
            }
            }

            return message;
        }

        public override void Write(Utf8JsonWriter writer, JobDataResponse message, JsonSerializerOptions options) =>
            throw new NotSupportedException();

        private void Expect(ref Utf8JsonReader reader, JsonTokenType t)
        {
            reader.Read();
            if (reader.TokenType != t)
                throw new JsonException();
        }

        private string ExpectString(ref Utf8JsonReader reader)
        {
            Expect(ref reader, JsonTokenType.String);
            return reader.GetString();
        }

        private decimal ExpectDecimal(ref Utf8JsonReader reader)
        {
            Expect(ref reader, JsonTokenType.Number);
            return reader.GetDecimal();
        }

        private bool Expect(ref Utf8JsonReader reader, JsonTokenType a, JsonTokenType b)
        {
            reader.Read();
            if (reader.TokenType == a) return true;
            if (reader.TokenType == b) return false;
            throw new JsonException();
        }
    }
}
