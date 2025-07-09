using API_Usuario.Context;
using API_Usuario.DTOs;
using API_Usuario.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Usuario.Services
{
    public class CargoService
    {
        public readonly Db _context;

        public CargoService(Db context)
        {
            _context = context;
        }

        public async Task<List<Cargo>> GetAllDesligamentos()
        {
            return await _context.Cargos
                .Include(f => f.Funcionarios)
                .ToListAsync();
        }
        public async Task<string> AddCargo(CargoDTOs dto)
        {
            var funcionario = await _context.Funcionarios.FindAsync(dto.FuncionarioId);
            if (funcionario == null) return "Funcionario não encontrado";

            Cargo cargo = new Cargo();
            cargo.Nome = dto.Nome;
            cargo.Funcionarios = (ICollection<Funcionario>)funcionario;

            await _context.Cargos.AddAsync(cargo);
            await _context.SaveChangesAsync();
            return "Cargo adicionado com sucesso!";
        }
        public async Task<string> UpdateCargo(int id, CargoDTOs dto)
        {
            var cargo = await _context.Cargos.Include(f => f.Funcionarios).FirstOrDefaultAsync(f => f.Id.Equals(id));
            if (cargo == null) return "Cargo não encontrado";

            var funcionario = await _context.Funcionarios.FindAsync(dto.FuncionarioId);
            if (funcionario == null) return "Cargo não encontrado";

            cargo.Nome = dto.Nome;
            cargo.Funcionarios = (ICollection<Funcionario>)funcionario;

            _context.Cargos.Update(cargo);
            await _context.SaveChangesAsync();
            return "Cargo atualizado com sucesso!";
        }
        public async Task<string> DeleteCargo(int id)
        {
            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo == null) return "Cargo não encontrado";

            _context.Cargos.Remove(cargo);
            await _context.SaveChangesAsync();
            return "Cargo removido com sucesso";
        }
    }
}
