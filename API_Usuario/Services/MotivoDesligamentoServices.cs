using API_Usuario.Context;
using API_Usuario.DTOs;
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

        public async Task<string> UpdateMotivoDesligamento(int id, MotivoDesligamentoDTOs dto)
        {
            var Update = await _Context.MotivoDesligamentos.Include(f => f.Funcionario).FirstOrDefaultAsync(f => f.Id.Equals(id));
            if (Update == null) return "Funcionario não encontrado";

            Update.Motivo = dto.Motivo;
            Update.Descricao = dto.Descricao;
            

            _Context.MotivoDesligamentos.Update(Update);
            await _Context.SaveChangesAsync();
            return "Motivo do Desligamento atualizado com sucesso";
        }
        public async Task<string> DeleteMotivoDesligamento(int id)
        {
            var Delete = await _Context.MotivoDesligamentos.FindAsync(id);
            if (Delete == null) return "Fit Cultural não encontrado";

            _Context.MotivoDesligamentos.Remove(Delete);
            await _Context.SaveChangesAsync();
            return "Motivo do Desligamento removido com sucesso";
        }

    }
}
