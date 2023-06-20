using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        private static List<WeatherForecast> Listforecasts=new List<WeatherForecast>();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            if (Listforecasts == null || !Listforecasts.Any())
            {
                Listforecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
               .ToList();
            }
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("La api esta retornando la lista");
            return Listforecasts;
        }
        [HttpPost]
        public IActionResult Post(WeatherForecast weatherForecast)
        {
            Listforecasts.Add(weatherForecast);
            return Ok();
            
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Listforecasts.RemoveAt(id);
            return Ok();
        }

        
    }
}