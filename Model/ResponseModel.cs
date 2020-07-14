using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DealCloud_BM.Model
{

        public partial class ResponseModel
    {
            //[JsonProperty("Meta Data")]
            //public MetaData MetaData { get; set; }

            [JsonProperty("Time Series (Daily)")]
            public Dictionary<string, TimeSeriesDaily> TimeSeriesDaily { get; set; }
        }

        public partial class MetaData
        {
            [JsonProperty("1. Information")]
            public string The1Information { get; set; }

            [JsonProperty("2. Symbol")]
            public string The2Symbol { get; set; }

            [JsonProperty("3. Last Refreshed")]
            public DateTimeOffset The3LastRefreshed { get; set; }

            [JsonProperty("4. Output Size")]
            public string The4OutputSize { get; set; }

            [JsonProperty("5. Time Zone")]
            public string The5TimeZone { get; set; }
        }

        public partial class TimeSeriesDaily
        {
            [JsonProperty("1. open")]
            public string Open { get; set; }

            [JsonProperty("2. high")]
            public string High { get; set; }

            [JsonProperty("3. low")]
            public string Low { get; set; }

            [JsonProperty("4. close")]
            public string Close { get; set; }

            [JsonProperty("5. volume")]
            //[JsonConverter(typeof(ParseStringConverter))]
            public string Volume { get; set; }
        }
    }
