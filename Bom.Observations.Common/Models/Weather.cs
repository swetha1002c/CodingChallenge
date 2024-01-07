using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bom.Observations.Common.Models
{
        public class Weather
        {
            [JsonPropertyName("air_temp")]
            public double Temperature { get; set; }

            [JsonPropertyName("local_date_time")]
            public string DateTime { get; set; } = string.Empty;

            [JsonPropertyName("apparent_t")]
            public double ApparentTemperature { get; set; }

            [JsonPropertyName("dewpt")]
            public double DewPoint { get; set; }

            [JsonPropertyName("rel_hum")]
            public int RelativeHumidity { get; set; }

            [JsonPropertyName("delta_t")]
            public double WetBulbDepression { get; set; }

            [JsonPropertyName("wind_dr")]
            public string WindDirection{ get; set; } = string.Empty;

            [JsonPropertyName("win_spd_kmh")]
            public int WindSpeedKmh { get; set; }

            [JsonPropertyName("win_spd_kt")]
            public int WindSpeedKts { get; set; }

            [JsonPropertyName("gust_kmh")]
            public int WindGustKmh { get; set; }

            [JsonPropertyName("gust_kt")]
            public int WindGustKts { get; set; }

            [JsonPropertyName("press_qnh")]
            public double PressureQnh { get; set; }

            [JsonPropertyName("press_msl")]
            public double PressureMsl { get; set; }

            [JsonPropertyName("rain_trace")]
            public double RainTraceMm { get; set; }

            [JsonPropertyName("name")]
            public string StationName { get; set; }= string.Empty;

        }
}
