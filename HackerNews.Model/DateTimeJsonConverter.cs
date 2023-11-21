using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HackerNews.Model
{
    public class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotImplementedException();

        public override void Write(Utf8JsonWriter writer, DateTime dateTimeValue, JsonSerializerOptions options) => writer.WriteStringValue(dateTimeValue.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ssK", CultureInfo.InvariantCulture));
    }
}
