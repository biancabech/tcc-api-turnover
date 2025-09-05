namespace API_Usuario.Models
{
    public class Grafico <T>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public T Valor { get; set; }
        public string Titulo { get; set; }
    }
}
