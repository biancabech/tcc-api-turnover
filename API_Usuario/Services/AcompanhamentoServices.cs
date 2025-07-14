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
            var funcionario = await _context.Funcionarios.FindAsync(dto.FuncionarioId);
            if (funcionario == null) return "Funcionario não encontrado";

            Acompanhamento acompanhamento = new Acompanhamento();
            acompanhamento.Data = dto.Data;
            acompanhamento.Proatividade = dto.Proatividade;
            acompanhamento.Qualidade = dto.Qualidade;
            acompanhamento.Prazos = dto.Prazos;
            acompanhamento.Comunicacao = dto.Comunicacao;
            acompanhamento.TrabalhoEquipe = dto.TrabalhoEquipe;
            acompanhamento.Adaptabilidade = dto.Adaptabilidade;
            acompanhamento.Feedback = dto.Feedback;
            acompanhamento.Treinamento = dto.Treinamento;
            acompanhamento.Plano = dto.Plano;
            acompanhamento.Avaliador = dto.Avaliador;
            acompanhamento.Confirmacao = dto.Confirmacao;
            acompanhamento.Funcionario = funcionario;

            

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
                Produtividade = dto.Produtividade,
                Qualidade = dto.Qualidade,
                Prazos = dto.Prazos,
                Comunicacao = dto.Comunicacao,
                TrabalhoEquipe = dto.TrabalhoEquipe,
                Adaptabilidade = dto.Adaptabilidade,
                Proatividade = dto.Proatividade,
                Feedback = dto.Feedback,
                Treinamento = dto.Treinamento,
                Plano = dto.Plano,
                Avaliador = dto.Avaliador,
                Confirmacao = dto.Confirmacao,
                Funcionario = dto.Funcionario
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
