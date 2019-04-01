using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_API.Models;

namespace Projeto_API.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }
        public Repository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        //FUNCIONARIOS

        public async Task<Funcionario[]> GetAllFuncionariosAsync(bool includeCargo = false)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;
            if (includeCargo)
            {
                query = query.Include(a => a.Cargo);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Funcionario[]> GetFuncionariosByCargoId(int CargoId, bool includeCargo)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;
            if (includeCargo)
            {
                query = query.Include(a => a.Cargo);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id).Where(funcionario => funcionario.CargoId == CargoId);
            return await query.ToArrayAsync();
        }

        public async Task<Funcionario> GetFuncionarioAsyncById(int FuncionarioId, bool includeCargo)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;
            if (includeCargo)
            {
                query = query.Include(a => a.Cargo);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id).Where(funcionario => funcionario.Id == FuncionarioId);
            return await query.FirstOrDefaultAsync();
        }

        //CARGOS

        public async Task<Cargo[]> GetAllCargosAsync(bool includeFuncionario = false)
        {
            IQueryable<Cargo> query = _context.Cargos;
            if (includeFuncionario)
            {
                query = query.Include(a => a.Funcionarios);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Cargo> GetCargoAsyncById(int CargoId, bool includeFuncionario = false)
        {
            IQueryable<Cargo> query = _context.Cargos;
            if (includeFuncionario)
            {
                query = query.Include(a => a.Funcionarios);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id).Where(Cargo => Cargo.Id == CargoId);
            return await query.FirstOrDefaultAsync();
        }
    }
}