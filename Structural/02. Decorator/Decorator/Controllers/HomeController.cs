using Decorator.Models;
using Decorator.Services.WeatherInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Decorator.Controllers
{
    public class HomeController : Controller
    {
        #region without DI
        //private readonly ILoggerFactory loggerFactory;
        //private readonly ILogger<HomeController> logger;
        //private readonly IWeatherService weatherService;
        //private readonly IMemoryCache cache;

        //public HomeController(ILoggerFactory logFactory, IConfiguration configuration, IMemoryCache memoryCache)
        //{
        //    loggerFactory = logFactory;
        //    logger = loggerFactory.CreateLogger<HomeController>();
        //    cache = memoryCache;

        //    string apiKey = configuration.GetValue<string>("OpenWeatherMapApiKey");

        //    // too cluttered onion
        //    //weatherService = new WeatherServiceLoggingDecorator(
        //    //    new WeatherService(apiKey),
        //    //    loggerFactory.CreateLogger<WeatherServiceLoggingDecorator>());

        //    IWeatherService inner = new WeatherService(apiKey);
        //    IWeatherService withLogging = new WeatherServiceLoggingDecorator(
        //        inner, loggerFactory.CreateLogger<WeatherServiceLoggingDecorator>());
        //    IWeatherService withCaching = new WeatherServiceCachingDecorator(
        //        withLogging, cache);
        //    weatherService = withCaching;
        //}
        #endregion

        private readonly ILogger<HomeController> logger;
        private readonly IWeatherService weatherService;

        public HomeController(ILogger<HomeController> loggerInterface,
                              IWeatherService weatherServiceInterface)
        {
            logger = loggerInterface;
            weatherService = weatherServiceInterface;
        }


        public IActionResult Index(string location = "Chicago")
        {
            CurrentWeather conditions = weatherService.GetCurrentWeather(location);
            return View(conditions);
        }

        public IActionResult Forecast(string location = "Chicago")
        {
            LocationForecast forecast = weatherService.GetForecast(location);
            return View(forecast);
        }

        public IActionResult ApiKey()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
