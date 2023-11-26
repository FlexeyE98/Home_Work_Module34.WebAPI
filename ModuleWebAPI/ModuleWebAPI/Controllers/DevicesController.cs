using Microsoft.AspNetCore.Mvc;

namespace ModuleWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public DevicesController(ILogger<WeatherForecastController> logger, IHostEnvironment hostEnvironment)
        {

            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        [HttpHead]
        [Route("{manufacture}")]
        public IActionResult GetManual([FromRoute] string manufacture)
        {
            var path = Path.Combine(_hostEnvironment.ContentRootPath, "Static");
            var filePath = Directory.GetFiles(path)
                .FirstOrDefault(f => f.Split("\\")
                .Last()
                .Split('.')[0] == manufacture);

            if (string.IsNullOrEmpty(filePath))
            {
                return StatusCode(400, "Билетик не найден товарищ!");
            }

            string fileType = "application/pdf";
            string fileName = $"{manufacture}.pdf";


            return PhysicalFile(filePath, fileType, fileName);
        }

    }
}
