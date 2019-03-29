namespace Projeto_API.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string DataNasc { get; set; }
        public int CargoId { get; set; }

        public Cargo Cargo { get; set; }
    }
}