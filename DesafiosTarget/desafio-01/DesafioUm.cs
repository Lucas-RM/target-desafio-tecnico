using DesafiosTarget.desafio_01.Models;
using System.Text.Json;

namespace DesafiosTarget.desafio_01
{
    public class DesafioUm
    {
        private readonly string _caminhoArquivo;

        public DesafioUm()
        {
            _caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "desafio-01", "registros-vendas.json");
        }

        public void Executar()
        {
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║         CALCULADORA DE COMISSÕES - TIME COMERCIAL          ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║  Regras de Comissão:                                       ║");
            Console.WriteLine("║  • Vendas < R$100,00  → Sem comissão                       ║");
            Console.WriteLine("║  • Vendas < R$500,00  → 1% de comissão                     ║");
            Console.WriteLine("║  • Vendas >= R$500,00 → 5% de comissão                     ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            var vendas = LerVendas();
            if (vendas == null || vendas.Count == 0)
            {
                Console.WriteLine("Nenhuma venda encontrada no arquivo.");
                return;
            }

            var comissoesPorVendedor = CalcularComissoes(vendas);
            ExibirResultados(comissoesPorVendedor);
        }

        private List<Venda> LerVendas()
        {
            try
            {
                string json = File.ReadAllText(_caminhoArquivo);
                var dados = JsonSerializer.Deserialize<DadosVendas>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return dados?.Vendas ?? new List<Venda>();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Erro: Arquivo não encontrado em {_caminhoArquivo}");
                return new List<Venda>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erro ao ler o JSON: {ex.Message}");
                return new List<Venda>();
            }
        }

        private Dictionary<string, ComissaoVendedor> CalcularComissoes(List<Venda> vendas)
        {
            var comissoesPorVendedor = new Dictionary<string, ComissaoVendedor>();

            foreach (var venda in vendas)
            {
                if (!comissoesPorVendedor.ContainsKey(venda.Vendedor))
                {
                    comissoesPorVendedor[venda.Vendedor] = new ComissaoVendedor
                    {
                        Nome = venda.Vendedor
                    };
                }

                var comissaoVendedor = comissoesPorVendedor[venda.Vendedor];
                comissaoVendedor.TotalVendas += venda.Valor;
                comissaoVendedor.QuantidadeVendas++;

                decimal comissao = CalcularComissaoVenda(venda.Valor);
                comissaoVendedor.TotalComissao += comissao;

                if (comissao == 0)
                    comissaoVendedor.VendasSemComissao++;
                else if (venda.Valor < 500)
                    comissaoVendedor.VendasComissao1Porcento++;
                else
                    comissaoVendedor.VendasComissao5Porcento++;
            }

            return comissoesPorVendedor;
        }

        private decimal CalcularComissaoVenda(decimal valorVenda)
        {
            if (valorVenda < 100)
                return 0;
            else if (valorVenda < 500)
                return valorVenda * 0.01m;
            else
                return valorVenda * 0.05m;
        }

        private void ExibirResultados(Dictionary<string, ComissaoVendedor> comissoesPorVendedor)
        {
            Console.WriteLine("┌────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                   RELATÓRIO DE COMISSÕES                   │");
            Console.WriteLine("└────────────────────────────────────────────────────────────┘");
            Console.WriteLine();

            decimal totalGeralComissoes = 0;
            decimal totalGeralVendas = 0;

            foreach (var item in comissoesPorVendedor.OrderByDescending(x => x.Value.TotalComissao))
            {
                var vendedor = item.Value;
                totalGeralComissoes += vendedor.TotalComissao;
                totalGeralVendas += vendedor.TotalVendas;

                Console.WriteLine($"┌─ {vendedor.Nome} ─────────────────────────────────────────────");
                Console.WriteLine($"│  Total de Vendas:      {vendedor.QuantidadeVendas} vendas");
                Console.WriteLine($"│  Valor Total:          {vendedor.TotalVendas:C}");
                Console.WriteLine($"│  ");
                Console.WriteLine($"│  Detalhamento:");
                Console.WriteLine($"│    • Vendas sem comissão (<R$100):    {vendedor.VendasSemComissao}");
                Console.WriteLine($"│    • Vendas com 1% (<R$500):          {vendedor.VendasComissao1Porcento}");
                Console.WriteLine($"│    • Vendas com 5% (>=R$500):         {vendedor.VendasComissao5Porcento}");
                Console.WriteLine($"│  ");
                Console.WriteLine($"│  - COMISSÃO TOTAL: {vendedor.TotalComissao:C}");
                Console.WriteLine($"└────────────────────────────────────────────────────────────");
                Console.WriteLine();
            }

            Console.WriteLine("╔════════════════════════════════════════════════════════════");
            Console.WriteLine($"║  RESUMO GERAL                                             ");
            Console.WriteLine($"║  Total de Vendas da Equipe: {totalGeralVendas,25:C}");
            Console.WriteLine($"║  Total de Comissões:        {totalGeralComissoes,25:C}");
            Console.WriteLine("╚════════════════════════════════════════════════════════════");
        }
    }
}
