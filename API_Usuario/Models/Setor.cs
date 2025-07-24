using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace API_Usuario.Models
{
    public class Setor
    {
        public Guid Id { get; set; } = new Guid();

        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

        
    }
}
