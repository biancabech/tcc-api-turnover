using System.Text.RegularExpressions;

namespace API_Usuario.Models
{
    public class DadosGraficoAnual
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ICollection<LabeledValue<string>> Units { get; set; } = new List<LabeledValue<string>>();
        public ICollection<LabeledValue<double>> TurnoverData { get; set; } = new List<LabeledValue<double>>();
        public ICollection<LabeledValue<double>> TerminationReasons { get; set; } = new List<LabeledValue<double>>();
        public ICollection<LabeledValue<double>> HiringReasons { get; set; } = new List<LabeledValue<double>>();
        public ICollection<LabeledValue<double>> DepartmentsWithTerminations { get; set; } = new List<LabeledValue<double>>();
        public ICollection<LabeledValue<double>> PositionsWithTerminations { get; set; } = new List<LabeledValue<double>>();
        public int AdmittedCount { get; set; }
        public int TerminatedCount { get; set; }
    }
}
