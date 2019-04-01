using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_API.Data;
using Projeto_API.Models;

namespace Projeto_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : Controller
    {
        public IRepository _repo { get; }
        public FuncionarioController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllFuncionariosAsync(true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("{FuncionarioId}")]
        public async Task<IActionResult> GetByFuncionarioId(int FuncionarioId)
        {
            try
            {
                var result = await _repo.GetFuncionarioAsyncById(FuncionarioId, true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("ByCargo/{CargoId}")]
        public async Task<IActionResult> GetByCargoId(int CargoId)
        {
            try
            {
                var result = await _repo.GetFuncionariosByCargoId(CargoId, true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Funcionario model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/funcionario/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpPut("{FuncionarioId}")]
        public async Task<IActionResult> put(int FuncionarioId, Funcionario model)
        {
            try
            {
                var funcionario = await _repo.GetFuncionarioAsyncById(FuncionarioId, false);
                if (funcionario == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    funcionario = await _repo.GetFuncionarioAsyncById(FuncionarioId, true);
                    return Created($"/api/funcionario/{model.Id}", funcionario);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpDelete("{FuncionarioId}")]
        public async Task<IActionResult> delete(int FuncionarioId)
        {
            try
            {
                var funcionario = await _repo.GetFuncionarioAsyncById(FuncionarioId, false);
                if (funcionario == null) return NotFound();

                _repo.Delete(funcionario);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }
    }
}