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

        public async Task<List<Cargo>> GetAllCargo()
        {
            return await _context.Cargos
                .Include(f => f.Funcionarios)
                .ToListAsync();
        }
        public async Task<string> AddCargo(CargoDTOs dto)
        { 

            Cargo cargo = new Cargo();
            cargo.Id = Guid.NewGuid();
            cargo.Nome = dto.Nome;
            

            await _context.Cargos.AddAsync(cargo);
            await _context.SaveChangesAsync();
            return "Cargo adicionado com sucesso!";
        }
        public async Task<string> UpdateCargo(Guid id, CargoDTOs dto)
        {
            var cargo = await _context.Cargos.FirstOrDefaultAsync(c => c.Id == id);
            if (cargo == null) return "Cargo não encontrado";

            cargo.Nome = dto.Nome;
           

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
