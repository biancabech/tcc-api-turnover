﻿using System.Text.Json.Serialization;
using API_Usuario.Models;

namespace API_Usuario.DTOs
{
    public class SetorDTO
    {
        public string Nome { get; set; }

        public Guid FuncionarioId { get; set; }
    }
}
