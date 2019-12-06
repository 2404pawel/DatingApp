using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    [Authorize] // wszystkie w ValuesController musi byc auhtorized request (czyli tokenen authorizowane)
    [ApiController]
    [Route("api/[controller]")]
        public class ValuesController : ControllerBase
        {
            private readonly DataContext _context;
            public ValuesController(DataContext context)
            {
                _context = context;
            }

            //GET api/values
            [HttpGet]
            public async Task<IActionResult> GetValues()
            {
                var values = await _context.Values.ToListAsync();
                
                return Ok(values);
            }

            //GET api/value/5
            [AllowAnonymous] //mozna pobrac wartosc id bez autoryzacji
            [HttpGet("{id}")]
            public async Task<IActionResult> GetValue(int id)
            {
                var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

                return Ok(value);
            }
        }
    // public class WeatherForecastController : ControllerBase
    // {
    //     private static readonly string[] Summaries = new[]
    //     {
    //         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //     };

    //     private readonly ILogger<WeatherForecastController> _logger;

    //     public WeatherForecastController(ILogger<WeatherForecastController> logger)
    //     {
    //         _logger = logger;
    //     }

    //     [HttpGet]
    //     public IEnumerable<WeatherForecast> Get()
    //     {
    //         var rng = new Random();
    //         return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //         {
    //             Date = DateTime.Now.AddDays(index),
    //             TemperatureC = rng.Next(-20, 55),
    //             Summary = Summaries[rng.Next(Summaries.Length)]
    //         })
    //         .ToArray();
    //     }
    // }
}
