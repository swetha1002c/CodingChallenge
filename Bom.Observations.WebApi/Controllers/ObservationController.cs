using Bom.Observations.Common;
using Bom.Observations.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bom.Observations.WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ObservationController : Controller
    {

        private readonly ILogger<ObservationController> _logger;

        public ObservationController(ILogger<ObservationController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{stationId}")]
        public async Task<ActionResult> GetData(string stationId, [FromQuery] string[] dataPoints)
        {
            try
            {

                foreach (var dataPoint in dataPoints)
                {
                    if (!IsValidDataPoint(dataPoint))
                    {
                        ModelState.AddModelError("dataPoints", $"Invalid data point: '{dataPoint}'.");
                    }
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                string apiUrl = $"http://www.bom.gov.au/fwo/IDS60901/IDS60901.{stationId}.json";

                List<Weather> weatherData = await BomObservations.GetWeatherObservationsAsync(apiUrl);
                if (weatherData.Any())
                {
                    if (dataPoints != null && dataPoints.Any())
                    {
                        return Ok(GetSpecificFieldData(weatherData, dataPoints));
                    }
                    else
                    {
                        var data = new Dictionary<string, List<Weather>>();
                        data[$"{weatherData[0].StationName}"] = weatherData;
                        return Ok(data);
                    }

                }
                else
                {
                    return Ok("No weather data available.");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        private bool IsValidDataPoint(string dataPoint)
        {
            string[] allowedDataPoints = { "temp", "apptemp", "dewpoint", "relhum", "deltat", "winddir",
            "windgustkmh", "windgustkts", "WindSpeedKmh", "WindSpeedKts", "PressureMsl", "PressureQnh","RainSince" };
            return allowedDataPoints.Contains(dataPoint.ToLowerInvariant());
        }
        private Dictionary<string, List<object>>? GetSpecificFieldData(List<Weather> weatherData, string[] dataPoints)
        {
            var specificFieldData = new Dictionary<string, List<object>>();
            foreach (var dataPoint in dataPoints)
            {
                switch (dataPoint.ToLower())
                {
                    case "temp":
                        specificFieldData["Temperature"] = (weatherData.Select(weather => (object)weather.Temperature).ToList());
                        break;
                    case "apptemp":
                        specificFieldData["ApparentTemperature"] = (weatherData.Select(weather => (object)weather.ApparentTemperature).ToList());
                        break;
                    case "dewpoint":
                        specificFieldData["DewPoint"] = (weatherData.Select(weather => (object)weather.DewPoint).ToList());
                        break;
                    case "relhum":
                        specificFieldData["RelativeHumidity"] = (weatherData.Select(weather => (object)weather.RelativeHumidity).ToList());
                        break;
                    case "deltat":
                        specificFieldData["WetBulbDepression"] = (weatherData.Select(weather => (object)weather.WetBulbDepression).ToList());
                        break;
                    case "winddir":
                        specificFieldData["WindDirection"] = (weatherData.Select(weather => (object)weather.WindDirection).ToList());
                        break;
                    case "windgustkmh":
                        specificFieldData["WindGustKmh"] = (weatherData.Select(weather => (object)weather.WindGustKmh).ToList());
                        break;
                    case "windgustkts":
                        specificFieldData["WindGustKts"] = (weatherData.Select(weather => (object)weather.WindGustKts).ToList());
                        break;
                    case "windspeedkmh":
                        specificFieldData["WindSpeedKmh"] = (weatherData.Select(weather => (object)weather.WindSpeedKmh).ToList());
                        break;
                    case "windspeedkts":
                        specificFieldData["WindSpeedKts"] = (weatherData.Select(weather => (object)weather.WindSpeedKts).ToList());
                        break;
                    case "pressmsl":
                        specificFieldData["PressureMsl"] = (weatherData.Select(weather => (object)weather.PressureMsl).ToList());
                        break;
                    case "pressqnh":
                        specificFieldData["PressureQnh"] = (weatherData.Select(weather => (object)weather.PressureQnh).ToList());
                        break;
                    case "rainsince":
                        specificFieldData["RainSince"] = (weatherData.Select(weather => (object)weather.RainTraceMm).ToList());
                        break;

                    default:
                        break;
                }
            }
            return specificFieldData;

        }
    }
}