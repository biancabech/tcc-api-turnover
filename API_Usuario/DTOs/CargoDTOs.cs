using API_Usuario.Models;

namespace API_Usuario.DTOs
{
    public class CargoDTOs
    {
        public string Nome { get; set; }

        public Funcionario Funcionario { get; set; }

        public Guid FuncionarioId { get; set; }
    }
}
