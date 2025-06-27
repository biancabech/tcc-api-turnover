namespace API_Usuario.Models
{
    public class Funcionario
    {
        public Guid id { get; set; } = new Guid();

        public string Nome { get; set; }

        public string Genero { get; set; }

        public string DataNasci { get; set; }

        public string DataAdmi { get; set; }    

        public string DataDemi { get; set; }

        public string Cargo { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}
