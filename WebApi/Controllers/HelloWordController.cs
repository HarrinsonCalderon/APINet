using Microsoft.AspNetCore.Mvc;
using webapi;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWordController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        //Se inyecta el servicio
        IHelloWordService helloWordService;

        TareasContext dbcontext;

        //se recibe con el contructor y se hace la referencia
        public HelloWordController(IHelloWordService helloWord, ILogger<WeatherForecastController> logger, TareasContext context )
        {
            helloWordService = helloWord;
            _logger = logger;
            dbcontext = context;
        }
        //se utiliza el servicio
        public IActionResult Get()
        {
            _logger.LogInformation("Tomando el hola mundo");
            return Ok(helloWordService.GetHelloWord());
        }
        //Metodo que si la bd no esta creada la crea de una, interesante para no usar los codigos por consola
        [HttpGet]
        [Route("Createdb")]
        public IActionResult CreateDatabase()
        {
            dbcontext.Database.EnsureCreated();
            return Ok();
        }
    }
}
