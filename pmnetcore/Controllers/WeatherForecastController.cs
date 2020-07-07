using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.ViewStore;
using Model.ViewStore.Entities;
using Newtonsoft.Json;

namespace pmnetcore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViewsController : ControllerBase
    {
        private readonly RelationalStoreContext _context;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ViewsController> _logger;

        public ViewsController(ILogger<ViewsController> logger, RelationalStoreContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            dynamic sampleObject = new ExpandoObject();
            sampleObject.key = "value";

            await _context.AddAsync(new Page
            {
                Id = Guid.NewGuid(),
                PageData = JsonConvert.SerializeObject(sampleObject),
                PageName = "IndexPage"
            });
            await _context.SaveChangesAsync();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //private createQueries()
    }
}
