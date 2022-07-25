using Microsoft.AspNetCore.Mvc;
using System.Text;
using M2MT_POC_002.Shared;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace M2MT_POC_002.BackendTwo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecastController(
            IHttpClientFactory httpClientFactory,
            ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        async public Task<IActionResult> Get()
        {
            var httpClient = _httpClientFactory.CreateClient();

            Console.WriteLine("hit 0");
            var message = new Message();
            message.content = "hallo wereld!";
            var content = new StringContent(JsonSerializer.Serialize(message), Encoding.UTF8, Application.Json);

            Console.WriteLine("hit 1");

            using var httpResponseMessage = await httpClient.PostAsync("http://onebackend/weatherforecast", content);
            Console.WriteLine("hit 2");
            httpResponseMessage.EnsureSuccessStatusCode();

            Console.WriteLine("hit 3");

            string redirectLocation = httpResponseMessage.Content.ReadAsStringAsync().Result;

            Console.WriteLine(redirectLocation);
            Console.Error.WriteLine(redirectLocation);

            return new RedirectResult(redirectLocation);
        }
    }
}