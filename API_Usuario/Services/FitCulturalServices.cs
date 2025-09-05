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
                .ToListAsync();
        }

        public async Task<FitCultural?> GetFitCultural(Guid id)
        {
            var fitCultural = await _context.FitCulturals.FindAsync(id);

            return fitCultural;
        }
        public async Task<string> AddFitCultural(FitCulturalDTOs dto)
        {
            FitCultural fitCultural = new FitCultural();
            fitCultural.Nome = dto.Nome;
            fitCultural.Descricao = dto.Descricao;
            fitCultural.Data = DateTime.Parse(dto.Data);

            await _context.FitCulturals.AddAsync(fitCultural);
            await _context.SaveChangesAsync();

            return "Fit Cultural adicionado com sucesso!";

        }
        public async Task<string> UpdateFitCultural(Guid id, FitCulturalDTOs dto)
        {
            var fitCultural = await _context.FitCulturals
                    .FirstOrDefaultAsync(f => f.Id.Equals(id));
            if (fitCultural == null) return "Fit Cultural não encontrado";

          

            fitCultural.Nome = dto.Nome;
            fitCultural.Descricao = dto.Descricao;
            fitCultural.Data = DateTime.Parse(dto.Data);


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

