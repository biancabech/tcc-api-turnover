using API_Usuario.Context;
using API_Usuario.DTOs;
using API_Usuario.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Usuario.Services
{
    public class DesligamentoServices
    {
        public readonly Db _context;

        public DesligamentoServices(Db context)
        {
            _context = context;
        }

        public async Task<List<Desligamento>> GetAllDesligamentos()
        {
            return await _context.Desligamentos
                .Include(f => f.Funcionario)
                .Include (f => f.Funcionario.Setor)
                .Include (f => f.Funcionario.Cargo)
                .ToListAsync();
        }

        public async Task<Desligamento?> GetDesligamento(Guid id)
        {
            var desligamento = await _context.Desligamentos
                .Include (f => f.Funcionario)
                .Include(f => f.Funcionario.Setor)
                .Include(f => f.Funcionario.Cargo)
                .Where (f => f.Id == id)
                .SingleAsync();

            return desligamento;
        }

        public async Task<string> AddDesligamento(DesligamentoDTOs dto)
        {
            Funcionario? funcionario = await _context.Funcionarios.FindAsync(dto.FuncionarioId);
            if (funcionario == null) return "Funcionario não encontrado";

            MotivoDesligamento? motivo = await _context.MotivoDesligamentos.FindAsync(dto.MotivoDesligamentoId);
            if (motivo == null) return "Motivo desligamento não encontrado";

            Desligamento desligamento = new Desligamento();
            desligamento.DataDesligamento = DateTime.Parse(dto.DataDesligamento);
            desligamento.isGrave = dto.isGrave;
            desligamento.Descricao = dto.Descricao;
            desligamento.FeedDesligamento = dto.Descricao;
            desligamento.Funcionario = funcionario;
            desligamento.MotivoDesligamento = motivo;

            await _context.Desligamentos.AddAsync(desligamento);
            await _context.SaveChangesAsync();

            return "Desligamento adicionado com sucesso!";
        }

        public async Task<string> UpdateDesligamento(Guid id, DesligamentoDTOs dto)
        {
            var desligamento = await _context.Desligamentos.Include(f => f.Funcionario).FirstOrDefaultAsync(f => f.Id.Equals(id));
            if (desligamento == null) return "Desligamento não encontrado";

            var funcionario = await _context.Funcionarios.FindAsync(dto.FuncionarioId);
            if (funcionario == null) return "Cargo não encontrado";

            desligamento.DataDesligamento = DateTime.Parse(dto.DataDesligamento);
            desligamento.isGrave = dto.isGrave;
            desligamento.Descricao = dto.Descricao;
            desligamento.FeedDesligamento = dto.FeedDesligamento;
            desligamento.Funcionario = funcionario;

            _context.Desligamentos.Update(desligamento);
            await _context.SaveChangesAsync();
            return "Desligamento atualizado com sucesso!";
        }
        public async Task<string> DeleteDesligamento(Guid id)
        {
            var desligamento = await _context.Desligamentos.FindAsync(id);
            if (desligamento == null) return "Desligamento não encontrado";

            _context.Desligamentos.Remove(desligamento);
            await _context.SaveChangesAsync();
            return "Desligamento removido com sucesso";
        }
    }
}
