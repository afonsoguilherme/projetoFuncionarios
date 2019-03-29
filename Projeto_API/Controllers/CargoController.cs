using Microsoft.AspNetCore.Mvc;

namespace Projeto_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : Controller
    {
        public CargoController()
        {
            
        }
        [HttpGet]
        public IActionResult Get ()
        {
            return Ok();
        }
        [HttpGet("{FuncionarioId}")]
        public IActionResult Get (int FuncionarioId)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult post ()
        {
            return Ok();
        }
        [HttpPut("{FuncionarioId}")]
        public IActionResult put (int CargoId)
        {
            return Ok();
        }
        [HttpDelete("{FuncionarioId}")]
        public IActionResult delete (int CargoId)
        {
            return Ok();
        }
        
    }
}