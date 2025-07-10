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
                .Include(f => f.NomeSetor)
                .ToListAsync();
        }
        public async Task<string> AddSetor(SetorDTO dto)
        {
            var funcionario = await _context.Funcionarios.FindAsync(dto.FuncionarioId);
            if (funcionario == null) return "Funcionario não encontrado";

            Setor setor = new Setor();
            setor.NomeSetor = dto.NomeSetor;
            setor.Funcionarios = (ICollection<Funcionario>)funcionario;

            await _context.Setores.AddAsync(setor);
            await _context.SaveChangesAsync();
            return "Setor adicionado com sucesso!";
        }
        public async Task<string> UpdateSetor(int id, SetorDTO dto)
        {
            var setor = await _context.Setores.Include(f => f.Funcionarios).FirstOrDefaultAsync(f => f.Id.Equals(id));
            if (setor == null) return "Setor não encontrado";

            var funcionario = await _context.Funcionarios.FindAsync(dto.FuncionarioId);
            if (funcionario == null) return "Cargo não encontrado";

            setor.NomeSetor = dto.NomeSetor;
            setor.Funcionarios = (ICollection<Funcionario>)funcionario;

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
    }
}
