namespace API_Usuario.Models
{
    public class FitCultural
    {
        public Guid Id { get; set; } = new Guid();

        public string Nome { get; set; }
        public string Data { get; set; }

        public string Observacoes { get; set; }

        public Funcionario Funcionario { get; set; }

    }
}
