namespace API_Usuario.Models
{
    public class Desligamento
    {
        public Guid Id { get; set; } = new Guid();

        public string DataDesligamento { get; set; }

        public bool isGrave { get; set; }

        public string Descricao { get; set; }

        public string FeedDesligamento { get; set; }
        
        public Funcionario Funcionario { get; set; }
    }
}
