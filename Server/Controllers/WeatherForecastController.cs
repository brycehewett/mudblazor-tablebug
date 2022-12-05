using Microsoft.AspNetCore.Mvc;
using MudBlazor.TableBug.Shared;

namespace MudBlazor.TableBug.Server.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult GetForecasts(TableState state)
        {
            var rng = new Random();
            var data = Enumerable.Range(1, 25).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });

            switch (state.SortLabel)
            {
                case "tempc":
                    data = data.OrderByDirection(state.SortDirection, o => o.TemperatureC);
                    break;
                case "tempf":
                    data = data.OrderByDirection(state.SortDirection, o => o.TemperatureF);
                    break;
                case "summary":
                    data = data.OrderByDirection(state.SortDirection, o => o.Summary);
                    break;
                default:
                    data = data.OrderByDirection(state.SortDirection, o => o.Date);
                    break;
            }

            return Ok(new TableData<WeatherForecast>() {
                TotalItems = data.Count(),
                Items = data.Skip(state.Page * state.PageSize).Take(state.PageSize)
            });
        }
    }
}
