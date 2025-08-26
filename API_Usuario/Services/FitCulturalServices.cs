using API_Usuario.Context;
using API_Usuario.DTOs;
using API_Usuario.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Usuario.Services
{
    public class FitCulturalServices
    {
        public readonly Db _context;

        public FitCulturalServices(Db context)
        {
            _context = context;
        }

        public async Task<List<FitCultural>> GetAllFitCulturals()
        {
            return await _context.FitCulturals
                .Include(f => f.Funcionario)
                .Include (f => f.Funcionario.Setor)
                .Include (f => f.Funcionario.Cargo)
                .ToListAsync();
        }

        public async Task<FitCultural?> GetFitCultural(Guid id)
        {
            var fitCultural = await _context.FitCulturals.FindAsync(id);

            return fitCultural;
        }
        public async Task<string> AddFitCultural(FitCulturalDTOs dto)
        {
            Funcionario funcionario = new Funcionario();
            FitCultural fitCultural = new FitCultural();
            fitCultural.Nome = dto.Nome;
            fitCultural.Descricao = dto.Descricao;
            fitCultural.Funcionario = funcionario;

            await _context.FitCulturals.AddAsync(fitCultural);
            await _context.SaveChangesAsync();
            return "Fit Cultural adicionado com sucesso!";

        }
        public async Task<string> UpdateFitCultural(Guid id, FitCulturalDTOs dto)
        {
            var fitCultural = await _context.FitCulturals.Include(f => f.Funcionario).FirstOrDefaultAsync(f => f.Id.Equals(id));
            if (fitCultural == null) return "Fit Cultural não encontrado";

            var funcionario = await _context.Funcionarios.FindAsync(dto.FuncionarioId);
            if (funcionario == null) return "Cargo não encontrado";

            fitCultural.Nome = dto.Nome;
            fitCultural.Descricao = dto.Descricao;
            fitCultural.Funcionario = funcionario;

            _context.FitCulturals.Update(fitCultural);
            await _context.SaveChangesAsync();
            return "Fit Cultural atualizado com sucesso";
        }
        public async Task<string> DeleteFitCultural(Guid id)
        {
            var fitCultural = await _context.FitCulturals.FindAsync(id);
            if (fitCultural == null) return "Fit Cultural não encontrado";

            _context.FitCulturals.Remove(fitCultural);
            await _context.SaveChangesAsync();
            return "Fit Cultural removido com sucesso";
        }
    }
}

