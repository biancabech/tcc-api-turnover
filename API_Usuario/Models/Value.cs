namespace API_Usuario.Models
{
    public class LabeledValue <T>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public T Value { get; set; }
        public string Label { get; set; }
    }
}
