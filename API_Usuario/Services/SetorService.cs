using API_Usuario.Context;
using API_Usuario.DTOs;
using API_Usuario.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Usuario.Services
{
    public class SetorService
    {
        public readonly Db _context;

        public SetorService(Db context)
        {
            _context = context;
        }

        public async Task<List<Setor>> GetAllSetor()
        {
            return await _context.Setores
                .ToListAsync();
        }
        public async Task<string> AddSetor(SetorDTO dto)
        {
            Setor setor = new Setor();

            setor.Id = Guid.NewGuid();
            setor.Nome = dto.Nome;
            

            await _context.Setores.AddAsync(setor);
            await _context.SaveChangesAsync();
            return "Setor adicionado com sucesso!";
        }

        public async Task<string> UpdateSetor(Guid id, SetorDTO dto)
        {
            var setor = await _context.Setores.FirstOrDefaultAsync(s => s.Id == id);
            if (setor == null) return "Setor não encontrado";

            setor.Nome = dto.Nome;

            _context.Setores.Update(setor);
            await _context.SaveChangesAsync();
            return "Setor atualizado com sucesso!";
        }

        public async Task<string> DeleteSetor(int id)
        {
            var setor = await _context.Setores.FindAsync(id);
            if (setor == null) return "Setor não encontrado";

            _context.Setores.Remove(setor);
            await _context.SaveChangesAsync();
            return "Setor removido com sucesso";
        }

        internal async Task<string> DeleteSetor(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
