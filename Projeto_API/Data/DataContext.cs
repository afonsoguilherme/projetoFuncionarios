using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Projeto_API.Models;

namespace Projeto_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Funcionario>()
                .HasData(
                    new List<Funcionario>(){
                        new Funcionario(){
                            Id = 1,
                            Nome = "Maria",
                            Sobrenome = "Silva",
                            DataNasc = "01/01/2000",
                            CargoId = 1
                        },
                        new Funcionario(){
                            Id = 2,
                            Nome = "João",
                            Sobrenome = "Souza",
                            DataNasc = "02/02/2000",
                            CargoId = 2
                        },
                        new Funcionario(){
                            Id = 3,
                            Nome = "José",
                            Sobrenome = "Oliveira",
                            DataNasc = "03/03/2000",
                            CargoId = 3
                        }
                    }
                );

            builder.Entity<Cargo>()
            .HasData(
                new List<Cargo>(){
                        new Cargo(){
                            Id = 1,
                            Nome = "Gerente"
                        },
                        new Cargo(){
                            Id = 2,
                            Nome = "Vendedor"
                        },
                        new Cargo(){
                            Id = 3,
                            Nome = "Entregador"
                        }
                }
            );
        }
    }
}