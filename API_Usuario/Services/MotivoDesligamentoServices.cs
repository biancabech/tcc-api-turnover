using API_Usuario.Context;
using API_Usuario.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Usuario.Services
{
    public class MotivoDesligamentoServices
    {
        public readonly Db _Context;

        public MotivoDesligamentoServices(Db context)
        {
            _Context = context;
        }

        public async Task<List<MotivoDesligamentos>> GetAllMotivoDesligamento()
        {
            return await  _Context.MotivoDesligamentos
                .Include(f => f.Desligamento)
                .ToListAsync();
        }

        public async Task<string> AddMotivoDesligamento(MotivoDesligamentos dto)
        {
            var cargo = await _Context.MotivoDesligamentos.FindAsync(dto.Funcionario);
            if (cargo == null) return "Desligamento não encontrado";

            MotivoDesligamentos motivoDesligamentos = new MotivoDesligamentos();
            motivoDesligamentos.Motivo = dto.Motivo;
            motivoDesligamentos.Descricao = dto.Descricao;
            motivoDesligamentos.Funcionario = dto.Funcionario;

            await _Context.SaveChangesAsync();
            return ("Motivo do Desligamento foi adicionado com Sucesso!");
  
        }

    }
}
