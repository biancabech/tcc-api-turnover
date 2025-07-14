using API_Usuario.Context;
using API_Usuario.DTOs;
using API_Usuario.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Usuario.Services
{
    public class AcompanhamentoServices
    {
        public readonly Db _context;

        public AcompanhamentoServices(Db context)
        {
            _context = context;
        }
        public async Task<List<Acompanhamento>> GetAllAcompanhamentos()
        {
            return await _context.Acompanhamentos
                .Include(f => f.Funcionario)
                .Include (f => f.Funcionario.Cargo)
                .Include (f => f.Funcionario.Setor)
                .ToListAsync();
                
        }
        public async Task<string> AddAcompanhamento(AcompanhamentoDTOs dto)
        {
            var funcionario = await _context.Acompanhamentos.FindAsync(dto.FuncionarioId);
            if (funcionario == null) return "Funcionario não encontrado";

            Acompanhamento acompanhamento = new Acompanhamento();
            acompanhamento.Data = dto.Data;
            acompanhamento.FeedEmpresa = dto.FeedEmpresa;
            acompanhamento.FeedFuncion = dto.FeedFuncion;
            acompanhamento.DataFeedBack = dto.DataFeedBack;
            acompanhamento.PontosAltos = dto.PontosAltos;
            acompanhamento.PontosBaixos = dto.PontosBaixos;

            

            await _context.Acompanhamentos.AddAsync(acompanhamento);
            await _context.SaveChangesAsync();
            return "Acompanhamento adicionado com Sucesso!";
        }

        public async Task<string> UpdateAcompanhamento(Guid id, Acompanhamento dto)
        {
            var acompanhamento = await _context.Acompanhamentos.Include(f => f.Funcionario).FirstOrDefaultAsync(f => f.Id.Equals(id));
            if (acompanhamento == null) return "Acompanhamento não encontrado";

            var acompanhamentos = new Acompanhamento
            {

                Data = dto.Data,
                DataFeedBack = dto.DataFeedBack,
                FeedEmpresa = dto.FeedEmpresa,
                FeedFuncion = dto.FeedFuncion,
                PontosBaixos = dto.PontosBaixos,
                PontosAltos = dto.PontosAltos
            };
                _context.Acompanhamentos.Update(acompanhamento);
                await _context.SaveChangesAsync();
                return "Motivo do Desligamento foi Atualizado!";
            }
        public async Task<string> DeleteAcompanhamento(Guid id)
        {
            var acompanhamento = await _context.Acompanhamentos.FindAsync(id);
            if (acompanhamento == null) return "Acompanhamento não encontrado";

            _context.Acompanhamentos.Remove(acompanhamento);
            await _context.SaveChangesAsync();
            return "Acompanhamento removido com sucesso";
        }

        internal async Task<string> UpdateAcompanhamento(Guid id, AcompanhamentoDTOs dto)
        {
            throw new NotImplementedException();
        }
    }
}
