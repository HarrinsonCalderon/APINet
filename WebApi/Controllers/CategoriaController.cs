using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        ICategoriaService categoriaService;
        public CategoriaController(ICategoriaService service)
        {
            categoriaService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
          return  Ok(categoriaService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            categoriaService.Save(categoria);
            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult Put(Guid Id,[FromBody] Categoria categoria)
        {
            categoriaService.Update(Id,categoria);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(Guid Id)
        {
            categoriaService.Delete(Id);
            return Ok();
        }
    }
}
