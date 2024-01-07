# Bom.Observations.ConsoleApp

>
> The console application is configured with a fixed URL, specifically http://www.bom.gov.au/fwo/IDS60901/IDS60901.94672.json,
>  to fetch observation data for Adelaide airport spanning the last 72 hours. This console app initiates calls to the API,
> processes the obtained data, and subsequently calculates the average temperature.
>  The final result, the average temperature, is then displayed as output within the console interface.
>

### Ouput 
<img width="1091" alt="image" src="https://github.com/swetha1002c/CodingChallenge/assets/155873478/58341761-d41e-4d11-ad8e-8a11d235c910">


# Bom.Observations.WebApi

>The ObservationController exposes an endpoint at [http://base_url/api/observation/95676], leveraging the **'stationId'** parameter to retrieve specific station observation data. This API supports query parameters ('datapoints'),
> enabling users to request particular data points within the response. For instance, upon accessing [http://base_url/api/observation/95676?datapoints=temp&datapoints=dewpoint],
> the response will precisely include temperature and dewpoint data as per the queried data points.

>To provide clarity in various scenarios, the API utilizes distinct status codes.
> A successful retrieval yields a 200 status code. In cases where model validation fails due to 'datapoints' not recognized as accepted inputs,
> the API responds with a 400 status code.
>Additionally, for any unforeseen server exceptions encountered during the process, the API ensures a reliable 500 status code response.


### Inputs

URL : http://base_url/api/observation/{stationId}
example inputs for *{stationId}*
* Adelaide Airport: **94672**
* Edinurgh: **95676**
* Hindmarsh Island: **94677**
* Kuitpo: **94683**

output: <img width="396" alt="image" src="https://github.com/swetha1002c/CodingChallenge/assets/155873478/10d5b81c-cfb9-44bc-b3f5-6c0b104419ca">

Query params to request specific piece of weather observation data [http://base_url/api/observation/95676?*datapoints=temp&datapoints=dewpoint*]

| Data Point  | Equilaent header |
| ------------- | ------------- |
| temp  | Temperature  |
| apptemp  | Apparent Temperature  |
| dewpoint  | DewPoint  |
| relhum  | Relative Humidity  |
| deltat  | WetBulbDepression  |
| winddir  | Wind Direction  |
| windgustkmh  | Wind Gust Kmh  |
| windspeedkmh  | Wind Speed Kmh  |
| windspeedkts  | WindSpeedKts  |
| pressmsl  | Pressure Msl  |
| pressqnh  | PressureQnh  |
| rainsince  | RainSince  |

> Other values return a data validation error

Output : ![image](https://github.com/swetha1002c/CodingChallenge/assets/155873478/1f75d028-0730-401f-b773-e218d4a0a845)

 
# Bom.Observations.Common

> Common models and functions are part of this library
