namespace API_Usuario.DTOs
{
    public class FuncionarioDTOs
    {
        public string Nome { get; set; }

        public string Genero { get; set; }

        public string Cpf { get; set; }

        public string DataNasci { get; set; }

        public string DataAdmi { get; set; }

        public string? DataDemi { get; set; }

        public string Email { get; set; }

        public Guid SetorId { get; set; }

        public Guid CargoId { get; set; }

    }
}
