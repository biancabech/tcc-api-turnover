namespace API_Usuario.Models
{
    public class Funcionario
    {
        public Guid Id { get; set; } = new Guid();

        public string Nome { get; set; }

        public string Genero { get; set; }

        public string DataNasci { get; set; }

        public string DataAdmi { get; set; }    

        public string DataDemi { get; set; }

        public string Email { get; set; }

        public Cargo Cargo { get; set; }
    }
}
