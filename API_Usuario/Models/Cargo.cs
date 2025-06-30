namespace API_Usuario.Models
{
    public class Cargo
    {
        public Guid Id { get; set; } = new Guid();

        public string Nome { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}
