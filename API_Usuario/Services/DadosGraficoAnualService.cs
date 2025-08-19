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
            List<LabeledValue<string>> turnoverPeriodos = await _context.Desligamentos.AsQueryable()
                .GroupBy(d => new { d.DataDesligamento.Year, d.DataDesligamento.Month })
                .Select(g => new LabeledValue<string>
                {
                    Label = $"{g.Key.Year}-{g.Key.Month:00}",
                    Value = g.Count().ToString()
                }).ToListAsync();

            List<LabeledValue<int>> motivosDesligamentos = await _context.Desligamentos.AsQueryable()
                .GroupBy(d => d.Descricao)
                //.Join(_context.MotivoDesligamentos.AsQueryable(),
                //    d => d.Key,
                //    m => m.Descricao,
                //    (d, m) => new { d.Key, Count = d.Count(), m.Id })
                .Select(g => new LabeledValue<int>
                {
                    Label = g.Key,
                    Value = g.Count()
                }).ToListAsync();

            List<LabeledValue<int>> desligamentosPorSetor = await _context.Desligamentos.AsQueryable()
                .Join(_context.Funcionarios.AsQueryable(),
                    d => d.FuncionarioId,
                    f => f.Id,
                    (d, f) => new { d, f })
                .Join(_context.Setores.AsQueryable(),
                    df => df.f.SetorId,
                    s => s.Id,
                    (df, s) => new { df.d, s.Nome })
                .GroupBy(d => d.Nome)
                .Select(g => new LabeledValue<int>
                {
                    Label = g.Key,
                    Value = g.Count()
                }).ToListAsync();

            List<LabeledValue<int>> desligamentosPorCargo = await _context.Desligamentos.AsQueryable()
                .GroupBy(d => d.Descricao)
                .Select(g => new LabeledValue<int>
                {
                    Label = g.Key,
                    Value = g.Count()
                }).ToListAsync();

            int qtdAdmitidos = await _context.Funcionarios.AsQueryable()
                .Select(f => f.Id)
                .Distinct()
                .CountAsync();

            int qtdDesligados = await _context.Desligamentos.AsQueryable()
                .Select(d => d.Id)
                .Distinct()
                .CountAsync();

            // retorna os dados do gráfico anual
            return new DadosGraficoAnual
            {
                Units = turnoverPeriodos.Select(p => new LabeledValue<string>
                {
                    Label = p.Label,
                    Value = p.Value
                }).ToList(),
                TurnoverData = turnoverPeriodos.Select(p => new LabeledValue<int>
                {
                    Label = p.Label,
                    Value = int.Parse(p.Value)
                }).ToList(),
                TerminationReasons = motivosDesligamentos,
                DepartmentsWithTerminations = desligamentosPorSetor,
                PositionsWithTerminations = desligamentosPorCargo,
                Ano = turnoverPeriodos.Select(p => p.Label.Split('-')[0]).Distinct().ToList(),
                Meses = turnoverPeriodos.Select(p => new LabeledValue<string>
                {
                    Label = p.Label.Split('-')[1],
                    Value = p.Label
                }).Distinct().ToList(),
                AdmittedCount = qtdAdmitidos,
                TerminatedCount = qtdDesligados
            };
        }
    }
}