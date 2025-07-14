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
                .ToListAsync();
        }

        public async Task<string> AddMotivoDesligamento(MotivoDesligamentoDTOs dto)
        {
            var motivo = await _Context.MotivoDesligamentos.FindAsync(dto.FuncionarioId);
            if (motivo == null) return "Desligamento não encontrado";

            var funcionario = await _Context.Funcionarios.FindAsync(dto.FuncionarioId);
            if (funcionario == null) return "Funcionário não encontrado";

            MotivoDesligamentos motivoDesligamentos = new MotivoDesligamentos();
            motivoDesligamentos.Motivo = dto.Motivo;
            motivoDesligamentos.Descricao = dto.Descricao;
            motivoDesligamentos.Funcionario = funcionario;

            _Context.MotivoDesligamentos.Add(motivoDesligamentos);
            await _Context.SaveChangesAsync();
            return "Motivo do Desligamento foi adicionado com Sucesso!";
        }

        public async Task<string> UpdateMotivoDesligamento(int id, MotivoDesligamentoDTOs dto)
        {
            var motivoDesligamento = await _Context.Desligamentos.Include(f => f.Id).FirstOrDefaultAsync(f => f.Id.Equals(id));
            if (motivoDesligamento == null) return "Desligamento não encontrado";

            var motivo = await _Context.MotivoDesligamentos.FindAsync(dto.DesligamentoId);
            if (motivo == null) return "Motivo não encontrado";

            motivo.Motivo = dto.Motivo;
            motivo.Descricao = dto.Descricao;

            _Context.MotivoDesligamentos.Update(motivo);
            await _Context.SaveChangesAsync();
            return "Motivo atualizado com sucesso";
        }

        public async Task<string> DeleteMotivoDesligamento(Guid id)
        {
            var motivo = await _Context.MotivoDesligamentos.FindAsync(id);
            if (motivo == null) return "Motivo não encontrado";

            _Context.MotivoDesligamentos.Remove(motivo);
            await _Context.SaveChangesAsync();
            return "Motivo removido com sucesso";
        }

        internal async Task<string> UpdateMotivoDesligamento(Guid id, MotivoDesligamentoDTOs dto)
        {
            throw new NotImplementedException();
        }
    }

}

