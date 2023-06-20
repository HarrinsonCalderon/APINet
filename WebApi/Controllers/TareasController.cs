using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        ITareaService tareaService;

        public TareasController(ITareaService service)
        {
            tareaService=service;
        }
        [HttpGet]
         public IActionResult Get()
        {
            return Ok(tareaService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea)
        {
            tareaService.Save(tarea);
            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult Put(Guid Id, [FromBody] Tarea tarea)
        {
            tareaService.Update(Id, tarea);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(Guid Id)
        {
            tareaService.Delete(Id);
            return Ok();
        }



    }
}
