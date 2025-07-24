using API_Usuario.Context;
using API_Usuario.DTOs;
using API_Usuario.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Usuario.Services
{
    public class EnderecoService
    {
        public readonly Db _context;

        public EnderecoService(Db context)
        {
            _context = context;
        }

        public async Task<List<Endereco>> GetAllEndereco()
        {
            return await _context.Enderecos
                .ToListAsync();

        }

        public async Task<string> AddEndereco(EnderecoDTOs dto)
        {
            Endereco endereco = new Endereco();
            endereco.Cep = dto.Cep;
            endereco.Numero = dto.Numero;
            endereco.Bairro = dto.Bairro;
            endereco.Cidade = dto.Cidade;
            endereco.Rua = dto.Rua;
            endereco.Complemento = dto.Complemento;
            endereco.Bairro = dto.Bairro;

            await _context.Enderecos.AddAsync(endereco);
            await _context.SaveChangesAsync();
            return "Endereço adicionado com sucesso!";
            
        }
        public async Task<string> UpdateEndereco(Guid id, EnderecoDTOs dto)

        {
            var endereco = await _context.Enderecos.FirstOrDefaultAsync(f => f.Id.Equals(id));
            endereco.Cep = dto.Cep;
            endereco.Numero = dto.Numero;
            endereco.Bairro = dto.Bairro;
            endereco.Cidade = dto.Cidade;
            endereco.Rua = dto.Rua;
            endereco.Complemento = dto.Complemento;
            endereco.Bairro = dto.Bairro;

            _context.Enderecos.Update(endereco);
            await _context.SaveChangesAsync();
            return "Endereço atualizado com sucesso";

        }
        public async Task<string> DeleteEndereco(Guid id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            await _context.SaveChangesAsync();
            return "Endereço removido com sucesso!";
        }
    }
}
