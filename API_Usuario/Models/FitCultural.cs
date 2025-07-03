namespace API_Usuario.Models
{
    public class FitCultural
    {
        public Guid Id { get; set; } = new Guid();

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public Funcionario Funcionario { get; set; }

    }
}
