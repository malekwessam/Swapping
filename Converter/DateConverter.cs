﻿using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;

namespace MoqaydaGP.Converter
{
    public class DateConverter : JsonConverter<DateTime>
    {
        private string formatDate = "dd/MM/yyyy";
        public override DateTime Read(ref Utf8JsonReader reader,
            Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), formatDate, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(formatDate));
        }
    }
}
