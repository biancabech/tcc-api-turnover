using API_Usuario.Context;
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
                .Include(f => f.DataDesligamento)
                .Include(f => f.FeedDesligamento)
                .Include(f => f.isGrave)
                .Include(f => f.Descricao)
                .ToListAsync();



        }
    }
}
