using System;
using System.Data;
using Newtonsoft.Json;
using UnityEngine;

namespace _Scripts.GrowthFund._Shared.Utility
{
    public class HexColorJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("This converter currently only supports deserialization");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var hex = (string)reader.Value;

            if (reader.TokenType == JsonToken.Null)
                throw new JsonReaderException(GetExceptionMessage($"{nameof(reader.TokenType)} was null."));

            if (!ColorUtility.TryParseHtmlString(hex, out var color))
                throw new DataException(GetExceptionMessage($"Couldn't parse hex {hex} into color."));
            return color;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Color) || objectType == typeof(Color32);
        }

        private static string GetExceptionMessage(string message)
        {
            return $"[{nameof(HexColorJsonConverter)}] {message}";
        }
    }
}