using API_Usuario.Models;

namespace API_Usuario.DTOs
{
    public class AcompanhamentoDTOs
    {
        public string Data { get; set; }

        public string FeedEmpresa { get; set; }

        public string FeedFuncion { get; set; }

        public string DataFeedBack { get; set; }

        public string PontosAltos { get; set; }

        public string PontosBaixos { get; set; }

        public Guid FuncionarioId { get; set; }

        
    }
}
