using API_Usuario.Context;
using API_Usuario.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Usuario.Services
{
    public class ValueService
    {
        public readonly Db _context;
        public ValueService(Db context)
        {
            _context = context;
        }

        public async Task<List<DadosGraficoAnual>> GetAllValue()
        {
            return await _context.GraficosAnuais
                .ToListAsync();
        }
    }
}
