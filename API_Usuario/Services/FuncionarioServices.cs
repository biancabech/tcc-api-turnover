using API_Usuario.Context;
using API_Usuario.DTOs;
using API_Usuario.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Usuario.Services
{
    public class FuncionarioServices
    {
        public readonly Db _context;

        public FuncionarioServices(Db context)
        {
            _context = context;
        }

        public async Task<List<Funcionario>> GetAllFuncionarios()
        {
            return await _context.Funcionarios
                .Include(f => f.Cargo)
                .ToListAsync();
        }

        public async Task<string> AddFuncionario(FuncionarioDTOs dto)
        {
            var cargo = await _context.Cargos.FindAsync(dto.CargoId);
            if (cargo == null) return "Cargo não encontrado";

            Funcionario funcionario = new Funcionario();
            funcionario.Nome = dto.Nome;
            funcionario.Genero = dto.Genero;
            funcionario.Cargo = cargo;

            funcionario.DataNasci = DateTime.Parse(dto.DataNasci);
            funcionario.DataAdmi = DateTime.Parse(dto.DataAdmi);
            funcionario.DataDemi = string.IsNullOrEmpty(dto.DataDemi) ? null : DateTime.Parse(dto.DataDemi);

            funcionario.Email = dto.Email;

            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();
            return "Funcionário adicionado com sucesso!";
        }

        public async Task<string> UpdateFuncionario(int id, FuncionarioDTOs dto)
        {
            var funcionario = await _context.Funcionarios.Include(f => f.Cargo).FirstOrDefaultAsync(f => f.Id.Equals(id));
            if (funcionario == null) return "Funcionário não encontrado";

            var cargo = await _context.Cargos.FindAsync(dto.CargoId);
            if (cargo == null) return "Cargo não encontrado";

            funcionario.Nome = dto.Nome;
            funcionario.Genero = dto.Genero;
            funcionario.Cargo = cargo;

            funcionario.DataNasci = DateTime.Parse(dto.DataNasci);
            funcionario.DataAdmi = DateTime.Parse(dto.DataAdmi);
            funcionario.DataDemi = string.IsNullOrEmpty(dto.DataDemi) ? null : DateTime.Parse(dto.DataDemi);

            funcionario.Email = dto.Email;

            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
            return "Funcionário atualizado com sucesso";
        }

        public async Task<string> DeleteFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null) return "Funcionário não encontrado";

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return "Funcionário removido com sucesso";
        }
    }
}
