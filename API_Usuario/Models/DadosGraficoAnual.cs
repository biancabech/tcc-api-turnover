using System.Text.RegularExpressions;

namespace API_Usuario.Models
{
    public class DadosGraficoAnual
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ICollection<LabeledValue<string>> Units { get; set; } = new List<LabeledValue<string>>();
        public ICollection<LabeledValue<int>> TurnoverData { get; set; } = new List<LabeledValue<int>>();
        public ICollection<LabeledValue<int>> TerminationReasons { get; set; } = new List<LabeledValue<int>>();
        public ICollection<LabeledValue<int>> HiringReasons { get; set; } = new List<LabeledValue<int>>();
        public ICollection<LabeledValue<int>> DepartmentsWithTerminations { get; set; } = new List<LabeledValue<int>>();
        public ICollection<LabeledValue<int>> PositionsWithTerminations { get; set; } = new List<LabeledValue<int>>();
        public ICollection<string> Ano { get; set; }
        public ICollection<LabeledValue<string>> Meses { get; set; }
        public int AdmittedCount { get; set; }
        public int TerminatedCount { get; set; }
    }
}
