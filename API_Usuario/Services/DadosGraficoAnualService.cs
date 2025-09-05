using API_Usuario.Context;
using API_Usuario.DTOs;
using API_Usuario.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Usuario.Services
{
    public class DadosGraficoAnualService
    {
        public readonly Db _context;
        public DadosGraficoAnualService(Db context)
        {
            _context = context;
        }

        public async Task<DadosGraficoAnual> GetGrafico()
        {
            // Turnover por período (mês/ano)
            var turnoverPeriodos = await _context.Desligamentos
                .GroupBy(d => new { d.DataDesligamento.Year, d.DataDesligamento.Month })
                .Select(g => new Grafico<int>
                {
                    Titulo = $"{g.Key.Month:00}/{g.Key.Year}",
                    Valor = g.Count()
                }).ToListAsync();

            // Motivos de desligamento (join e count)
            var motivosDesligamentos = await _context.Desligamentos
                .GroupBy(d => d.MotivoDesligamento.Motivo)
                .Select(g => new Grafico<int>
                {
                    Titulo = g.Key,
                    Valor = g.Count()
                }).ToListAsync();

            // Desligamentos por setor
            var desligamentosPorSetor = await _context.Desligamentos
                .Join(_context.Funcionarios,
                    d => d.FuncionarioId,
                    f => f.Id,
                    (d, f) => new { d, f })
                .Join(_context.Setores,
                    df => df.f.SetorId,
                    s => s.Id,
                    (df, s) => new { df.d, s.Nome })
                .GroupBy(x => x.Nome)
                .Select(g => new Grafico<int>
                {
                    Titulo = g.Key,
                    Valor = g.Count()
                }).ToListAsync();

            // Desligamentos por cargo
            var desligamentosPorCargo = await _context.Desligamentos
                .Join(_context.Funcionarios,
                    d => d.FuncionarioId,
                    f => f.Id,
                    (d, f) => new { d, f })
                .Join(_context.Cargos,
                    df => df.f.CargoId,
                    c => c.Id,
                    (df, c) => new { df.d, c.Nome })
                .GroupBy(x => x.Nome)
                .Select(g => new Grafico<int>
                {
                    Titulo = g.Key,
                    Valor = g.Count()
                }).ToListAsync();

            // Quantidade de admitidos
            int qtdAdmitidos = await _context.Funcionarios.CountAsync();

            // Quantidade de desligados
            int qtdDesligados = await _context.Desligamentos.CountAsync();

            // Retorno dos dados do gráfico anual
            return new DadosGraficoAnual
            {
                DadosTurnover = turnoverPeriodos.Select(p => new Grafico<int>
                {
                    Titulo = p.Titulo,
                    Valor = p.Valor,
                }).ToList(),
                MotivosDeDesligamento = motivosDesligamentos,
                DesligamentosPorSetor = desligamentosPorSetor,
                DesligamentosPorCargos = desligamentosPorCargo,
                Ano = turnoverPeriodos.Select(p => p.Titulo.Split('/')[1]).Distinct().ToList(),
                Meses = turnoverPeriodos.Select(p => new Grafico<string>
                {
                    Titulo = p.Titulo.Split('/')[0],
                    Valor = p.Titulo
                }).Distinct().ToList(),
                QtdeAdmitidos = qtdAdmitidos,
                QtdeDesligados = qtdDesligados
            };
        }
    }
}