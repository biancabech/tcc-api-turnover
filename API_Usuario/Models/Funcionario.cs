using System.ComponentModel.DataAnnotations.Schema;

namespace API_Usuario.Models
{
    public class Funcionario
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNasci { get; set; }
        public DateTime DataAdmi { get; set; }
        public DateTime? DataDemi { get; set; }
        public string Email { get; set; }
        public Guid CargoId { get; set; }
        public Cargo Cargo { get; set; }
        public Guid SetorId { get; set; }
        public Setor Setor { get; set; }
    }
}