namespace API_Usuario.DTOs
{
    public class MotivoDesligamentoDTOs
    {
        public string Motivo { get; set; }

        public string Descricao { get; set; }

        public Guid DesligamentoId { get; set; }
        public Guid FuncionarioId { get; set; }
    }
}
