using System.Threading.Tasks;
using Projeto_API.Models;

namespace Projeto_API.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //FUNCIONARIO
        Task<Funcionario[]> GetAllFuncionariosAsync(bool includeCargo);
        Task<Funcionario[]> GetFuncionariosByCargoId(int CargoId, bool includeCargo);
        Task<Funcionario> GetFuncionarioAsyncById(int FuncionarioId, bool includeCargo);

        //CARGO
        Task<Cargo[]> GetAllCargosAsync(bool includeFuncionario);
        Task<Cargo> GetCargoAsyncById(int CargoId, bool includeFuncionario);
    }
}