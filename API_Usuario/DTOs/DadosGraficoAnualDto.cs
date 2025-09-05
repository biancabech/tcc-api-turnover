using API_Usuario.Models;

namespace API_Usuario.DTOs
{
    public class DadosGraficoAnualDto
    {
        public ICollection<string> Ano {  get; set; }
        public ICollection<Grafico<string>> Meses { get; set; }
    }
}
