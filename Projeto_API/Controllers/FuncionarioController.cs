using Microsoft.AspNetCore.Mvc;

namespace Projeto_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : Controller
    {
        public FuncionarioController()
        {
            
        }
        [HttpGet]
        public IActionResult Get ()
        {
            return Ok();
        }
        [HttpGet("{CargoId}")]
        public IActionResult Get (int CargoId)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult post ()
        {
            return Ok();
        }
        [HttpPut("{CargoId}")]
        public IActionResult put (int FuncionarioId)
        {
            return Ok();
        }
        [HttpDelete("{CargoId}")]
        public IActionResult delete (int FuncionarioId)
        {
            return Ok();
        }
    }
}