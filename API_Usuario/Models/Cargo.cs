using System.Text.Json.Serialization;

namespace API_Usuario.Models
{
    public class Cargo
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}
