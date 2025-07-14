using API_Usuario.Models;

namespace API_Usuario.DTOs
{
    public class AcompanhamentoDTOs
    {
        public DateTime Data  { get; set; }
        public string Produtividade { get; set; }
        public string Qualidade { get; set; }
        public string Prazos { get; set; }
        public bool Comunicacao { get; set; }
        public bool TrabalhoEquipe { get; set; }
        public bool Adaptabilidade { get; set; }
        public bool Proatividade { get; set; }
        public string Feedback { get; set; }
        public string Treinamento { get; set; }
        public string Plano { get; set; }
        public string Avaliador { get; set; }
        public string Confirmacao { get; set; }
        public Guid FuncionarioId { get; set; }

        
    }
}
