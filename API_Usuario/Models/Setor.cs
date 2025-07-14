using System.Security.Cryptography.X509Certificates;

namespace API_Usuario.Models
{
    public class Setor
    {
        public Guid Id { get; set; } = new Guid();

        public string NomeSetor { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

        
    }
}
