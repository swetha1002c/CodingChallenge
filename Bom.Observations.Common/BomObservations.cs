using Bom.Observations.Common.Models;
using System.Net.Http.Json;

namespace Bom.Observations.Common
{
    public class BomObservations
    {
        public static async Task<List<Weather>> GetWeatherObservationsAsync(string apiUrl)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            WeatherDataResponse weatherDataResponse = await response.Content.ReadFromJsonAsync<WeatherDataResponse>();

            if (weatherDataResponse != null && weatherDataResponse.Observations != null && weatherDataResponse.Observations.Data.Any())
            {
                return weatherDataResponse.Observations.Data;
            }
            else
            {
                return new List<Weather>();
            }
        }
    }
}
