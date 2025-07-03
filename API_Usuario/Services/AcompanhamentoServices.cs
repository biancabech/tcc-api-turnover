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
        public async Task<List<Acompanhamento>> GetAcompanhamentos()
        {
            return await _context.Acompanhamentos
                .Include(f => f.Data)
                .Include(f => f.FeedEmpresa)
                .Include(f => f.FeedFuncion)
                .Include(f => f.DataFeedBack)
                .Include(f => f.PontosAltos)
                .Include(f => f.PontosBaixos)
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

            

            await _context.Funcionarios.AddAsync(acompanhamento);
            await _context.SaveChangesAsync();
            return "Acompanhamento adicionado com Sucesso!";
        }

    }
}
