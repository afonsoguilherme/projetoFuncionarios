using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_API.Data;
using Projeto_API.Models;

namespace Projeto_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : Controller
    {
        public IRepository _repo { get; }
        public CargoController(IRepository repo)
        {
            _repo = repo;

        }
        [HttpGet]
        public async Task<IActionResult> get()
        {
            try
            {
                var results = await _repo.GetAllCargosAsync(true);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }
        [HttpGet("{CargoId}")]
        public async Task<IActionResult> getByCargoId(int CargoId)
        {
            try
            {
                var results = await _repo.GetFuncionarioAsyncById(CargoId, true);
                return Ok();
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }
        [HttpPost]
        public async Task<IActionResult> post(Cargo model)
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
        [HttpPut("{CargoId}")]
        public async Task<IActionResult> Put(int CargoId, Cargo model)
        {
            try
            {
                var Cargo = await _repo.GetCargoAsyncById(CargoId, false);
                if (Cargo == null) return NotFound();
                _repo.Update(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"api/Cargo/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
            return BadRequest();
        }
        [HttpDelete("{CargoId}")]
        public async Task<IActionResult> Delete(int CargoId)
        {
            try
            {
                var Cargo = await _repo.GetCargoAsyncById(CargoId, false);
                if (Cargo == null) return NotFound();
                _repo.Delete(Cargo);
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