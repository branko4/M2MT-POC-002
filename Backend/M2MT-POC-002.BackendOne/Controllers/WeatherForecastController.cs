using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using M2MT_POC_002.Shared;

namespace M2MT_POC_002.BackendOne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static Dictionary<string, string> messages = new Dictionary<string, string>();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new RedirectResult("/one/fe/");
        }

        [HttpGet]
        [Route("{messageId}")]
        public Message GetMessage(string messageId)
        {
            Console.WriteLine(messageId);
            string message = messages[messageId];
            //if (message != null)  NotFound();
            //foreach (var item in messages)
            //{
            //    Console.WriteLine(item.Value);
            //    Console.WriteLine(item.Key);
            //}
            var messageObject = new Message();
            messageObject.content = message;
            return messageObject;
        }

        [HttpPost]
        [Consumes("application/json")]
        public string Post(Message message)
        {
            Console.WriteLine(message);

            Guid guid = Guid.NewGuid();

            messages.Add(guid.ToString(), message.content);
            Console.WriteLine(guid.ToString());

            return $"/one/fe/message/{guid}";
        }
    }
}