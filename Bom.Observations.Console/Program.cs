using Bom.Observations.Common.Models;
using Bom.Observations.Common;

namespace Bom.Observations.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                string apiUrl = $"http://www.bom.gov.au/fwo/IDS60901/IDS60901.94672.json";

                List<Weather> weatherData = await BomObservations.GetWeatherObservationsAsync(apiUrl);
                if(weatherData.Any()) { 
                double averageTemperature = weatherData.Average(airTemp => airTemp.Temperature);

                Console.WriteLine($"Average Temperature for {weatherData[0].StationName}: {averageTemperature} °C");
                }
                else
                {
                    Console.WriteLine("No weather data available.");
                }
            }

            catch (Exception ex)
            { 
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
