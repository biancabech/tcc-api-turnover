using API_Usuario.Context;
using API_Usuario.DTOs;
using API_Usuario.Models;
using Aspire.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;
using OllamaSharp;
using OllamaSharp.Models.Chat;

namespace API_Usuario.Services
{
    public class IaIndicaServices
    {
        private Uri _uri;
        private OllamaApiClient _ollama;
        private DadosGraficoAnualService _dadosGraficoAnualService;

        public IaIndicaServices(
            DadosGraficoAnualService dadosGraficoAnualService
        )
        {
            _dadosGraficoAnualService = dadosGraficoAnualService;
            _uri = new Uri("http://localhost:11434");
            _ollama = new OllamaApiClient(_uri);
            _ollama.SelectedModel = "deepscaler:1.5b";
        }

        public async Task<string> Analisar()
        {
            string? prompt = await this.Prompt();
            if (prompt == null)
            {
                return "Não há dados para análise.";
            }

            var chat = new ChatRequest
            {
                Model = _ollama.SelectedModel,
                Messages = new List<Message>
                {
                    new Message { Role = "system", Content = "Você é um analista senior de Recursos Humanos especialista em turnover" },
                    new Message { Role = "user", Content = prompt }
                }
            };

            IAsyncEnumerable<ChatResponseStream?> response = _ollama.ChatAsync(chat);
            string respostaFinal = "";
            bool thinking = true;

            await foreach (ChatResponseStream resp in _ollama.ChatAsync(chat))
            {
                if (!string.IsNullOrEmpty(resp?.Message?.Content))
                {
                    if (!thinking)
                    {
                        respostaFinal += resp.Message.Content;
                    }
                    else
                    {
                        bool terminouDePensar = resp.Message.Content == "</think>";
                        if (terminouDePensar)
                        {
                            thinking = false;
                        }
                    }
                }
            }

            return respostaFinal;
        }


        private async Task<string?> Prompt()
        {
            DadosGraficoAnual dados = await this._dadosGraficoAnualService.GetGrafico();

            if (dados == null)
            {
                return null;
            }

            string prompt = "Esses são os dados do relatório\n";

            prompt += "Quantidade admitidos: " + dados.QtdeAdmitidos + "\n";
            prompt += "Quantidade desligados: " + dados.QtdeDesligados + "\n";

            prompt += "Motivos de desligamento: \n";
            prompt += this.ConcatenarDados(dados.MotivosDeDesligamento);

            prompt += "Motivos por setor: ";
            prompt += this.ConcatenarDados(dados.DesligamentosPorSetor);

            prompt += "Motivos por setor: ";
            prompt += this.ConcatenarDados(dados.DesligamentosPorCargos);

            prompt += "Períodos:";
            prompt += this.ConcatenarDados(dados.DadosTurnover);

            prompt += "Faça uma análise rápida nesses dados e me de 3 sugestões, " +
                "em tópicos, cada item separado e alinhado, tópicos de campanhas que posso fazer para ajudar na retenção " +
                "dos meus funcionários. Retorne no formato markdown.";

            return prompt;
        }

        private string ConcatenarDados(ICollection<Grafico<int>> dados)
        {
            string valores = "";
            foreach (var setor in dados)
            {
                valores += "  [Motivo]: " + setor.Titulo + " [Quantidade]: " + setor.Valor + "\n";
            }

            valores += "\n\n";


            return valores;
        }

    }
}