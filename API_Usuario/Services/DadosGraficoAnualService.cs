using API_Usuario.Context;
using API_Usuario.DTOs;
using API_Usuario.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Usuario.Services
{
    public class DadosGraficoAnualService
    {
        public readonly Db _context;
        public DadosGraficoAnualService(Db context)
        {
            _context = context;
        }

        public async Task<List<DadosGraficoAnual>> GetAllGrafico()
        {
            return await _context.DadosGraficosAnuais
                .ToListAsync();
        }
        public async Task<string> AddGraficoAnual(DadosGraficoAnualDto dto)
        {
            DadosGraficoAnual dadosGraficoAnual = new DadosGraficoAnual();
            dadosGraficoAnual.Ano = dto.Ano;
            dadosGraficoAnual.Meses = dto.Meses;

            await _context.DadosGraficosAnuais.AddAsync(dadosGraficoAnual);
            await _context.SaveChangesAsync();
            return "Grafico adicionado com sucesso";
        }
        public async Task<string> UpdateGraficoAnual (Guid id, DadosGraficoAnualDto dto)
        {
            var dadosGraficoAnual = await _context.DadosGraficosAnuais.FirstOrDefaultAsync(d => d.Id == id);
            if (dadosGraficoAnual == null) return "Grafico não encontrado";

            dadosGraficoAnual.Ano = dto.Ano;
            dadosGraficoAnual.Meses = dto.Meses;

            _context.DadosGraficosAnuais.Update(dadosGraficoAnual);
            await _context.SaveChangesAsync();
            return "Grafico atualizado com sucesso";

        }
        public async Task<string> DeleteGrafico(Guid id)
        {
            var dadosGraficoAnual = await _context.DadosGraficosAnuais.FindAsync(id);
            if (dadosGraficoAnual == null) return "Grafico não encontrado";
            _context.DadosGraficosAnuais.Remove(dadosGraficoAnual);
            await _context.SaveChangesAsync();
            return "Grafico deletado com sucesso";

        }
    }
}