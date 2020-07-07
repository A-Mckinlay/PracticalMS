using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.MessageStore;
using Model.ViewStore;
using Model.ViewStore.Entities;
using Newtonsoft.Json;

namespace pmnetcore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViewsController : ControllerBase
    {
        private readonly RelationalStoreContext _viewStore;
        private readonly IMessageStore _messageStore;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ViewsController> _logger;

        public ViewsController(ILogger<ViewsController> logger, RelationalStoreContext viewStoreContext, IMessageStore messageStore)
        {
            _logger = logger;
            _viewStore = viewStoreContext;
            _messageStore = messageStore;
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            dynamic sampleObject = new ExpandoObject();
            sampleObject.key = "value";

            var page = new Page
            {
                Id = Guid.NewGuid(),
                PageData = JsonConvert.SerializeObject(sampleObject),
                PageName = "IndexPage"
            };

            await _viewStore.AddAsync(page);
            await _viewStore.SaveChangesAsync();

            var streamId = "streamIdentifier";
            await _messageStore.AppendToStream(streamId, 0, new SimpleEventStore.EventData(Guid.NewGuid(), page));
            var dataFromMsgStore = await _messageStore.ReadStreamForwards(streamId);

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
