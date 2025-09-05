using System.Text.RegularExpressions;

namespace API_Usuario.Models
{
    public class DadosGraficoAnual
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ICollection<Grafico<int>> DadosTurnover { get; set; } = new List<Grafico<int>>();
        public ICollection<Grafico<int>> MotivosDeDesligamento { get; set; } = new List<Grafico<int>>();
        public ICollection<Grafico<int>> DesligamentosPorSetor { get; set; } = new List<Grafico<int>>();
        public ICollection<Grafico<int>> DesligamentosPorCargos { get; set; } = new List<Grafico<int>>();
        public ICollection<string> Ano { get; set; }
        public ICollection<Grafico<string>> Meses { get; set; }
        public int QtdeAdmitidos { get; set; }
        public int QtdeDesligados { get; set; }
    }
}
