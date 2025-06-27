namespace API_Usuario.Models
{
    public class Acompanhamento
    {
        public Guid Id { get; set; }

        public string Data {  get; set; }

        public string FeedEmpresa { get; set; }

        public string FeedFuncion {  get; set; }

        public string DataFeedBack { get; set; }

        public string PontosAltos { get; set; }

        public string PontosBaixos { get; set; }

        public Funcionario Funcionario { get; set; }
    }
}
