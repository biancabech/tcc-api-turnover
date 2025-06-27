namespace API_Usuario.Models
{
    public class MotivoDesligamentos
    {
        public Guid Id { get; set; } = new Guid();

        public string Motivo { get; set; }

        public string Descricao { get; set; }
    }
}
