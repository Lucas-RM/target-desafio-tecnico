using DesafiosTarget.desafio_02.Models;
using System.Text.Json;

namespace DesafiosTarget.desafio_02
{
    public class DesafioDois
    {
        private readonly string _caminhoArquivo;
        private List<Produto> _produtos;
        private List<Movimentacao> _movimentacoes;
        private int _proximoIdMovimentacao;

        public DesafioDois()
        {
            _caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "desafio-02", "estoque-dos-produtos.json");
            _produtos = new List<Produto>();
            _movimentacoes = new List<Movimentacao>();
            _proximoIdMovimentacao = 1;
        }

        public void Executar()
        {
            CarregarProdutos();

            if (_produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto encontrado no arquivo.");
                return;
            }

            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                ExibirMenuMovimentacao();
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RealizarMovimentacao("ENTRADA");
                        break;
                    case "2":
                        RealizarMovimentacao("SAIDA");
                        break;
                    case "3":
                        ExibirEstoqueAtual();
                        break;
                    case "4":
                        ExibirHistoricoMovimentacoes();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        private void ExibirMenuMovimentacao()
        {
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           CONTROLE DE MOVIMENTAÇÃO DE ESTOQUE              ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║   [1] Entrada de Mercadoria                                ║");
            Console.WriteLine("║   [2] Saída de Mercadoria                                  ║");
            Console.WriteLine("║   [3] Consultar Estoque Atual                              ║");
            Console.WriteLine("║   [4] Histórico de Movimentações                           ║");
            Console.WriteLine("║   [0] Voltar ao Menu Principal                             ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.Write("\nEscolha uma opção: ");
        }

        private void CarregarProdutos()
        {
            try
            {
                string json = File.ReadAllText(_caminhoArquivo);
                var dados = JsonSerializer.Deserialize<DadosEstoque>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                _produtos = dados?.Estoque ?? new List<Produto>();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Erro: Arquivo não encontrado em {_caminhoArquivo}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erro ao ler o JSON: {ex.Message}");
            }
        }

        private void RealizarMovimentacao(string tipo)
        {
            Console.Clear();
            Console.WriteLine($"╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║             {(tipo == "ENTRADA" ? "ENTRADA" : "  SAÍDA")} DE MERCADORIA                          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            ExibirListaProdutos();

            Console.Write("\nDigite o código do produto: ");
            if (!int.TryParse(Console.ReadLine(), out int codigoProduto))
            {
                Console.WriteLine("Código inválido!");
                AguardarTecla();
                return;
            }

            var produto = _produtos.FirstOrDefault(p => p.CodigoProduto == codigoProduto);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado!");
                AguardarTecla();
                return;
            }

            Console.Write("Digite a quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
            {
                Console.WriteLine("Quantidade inválida!");
                AguardarTecla();
                return;
            }

            if (tipo == "SAIDA" && quantidade > produto.Estoque)
            {
                Console.WriteLine($"Estoque insuficiente! Disponível: {produto.Estoque}");
                AguardarTecla();
                return;
            }

            Console.Write("Digite a descrição da movimentação: ");
            string descricao = Console.ReadLine() ?? "";

            // Atualiza o estoque
            if (tipo == "ENTRADA")
                produto.Estoque += quantidade;
            else
                produto.Estoque -= quantidade;

            // Registra a movimentação
            var movimentacao = new Movimentacao
            {
                Id = _proximoIdMovimentacao++,
                Descricao = descricao,
                CodigoProduto = codigoProduto,
                TipoMovimentacao = tipo,
                Quantidade = quantidade,
                DataMovimentacao = DateTime.Now
            };
            _movimentacoes.Add(movimentacao);

            // Exibe resultado
            ExibirResultadoMovimentacao(movimentacao, produto);
        }

        private void ExibirResultadoMovimentacao(Movimentacao movimentacaoAtual, Produto produtoAtual)
        {
            Console.WriteLine();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              MOVIMENTAÇÃO REALIZADA COM SUCESSO            ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.WriteLine($"║  ID Movimentação: {movimentacaoAtual.Id,-40} ║");
            Console.WriteLine($"║  Tipo: {movimentacaoAtual.TipoMovimentacao,-51} ║");
            Console.WriteLine($"║  Produto: {produtoAtual.DescricaoProduto,-48} ║");
            Console.WriteLine($"║  Quantidade: {movimentacaoAtual.Quantidade,-45} ║");
            Console.WriteLine($"║  Descrição: {movimentacaoAtual.Descricao,-46} ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.WriteLine($"║  ESTOQUE FINAL: {produtoAtual.Estoque,-42} ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            AguardarTecla();
        }

        private void ExibirListaProdutos()
        {
            Console.WriteLine("┌────────┬────────────────────────────────┬──────────┐");
            Console.WriteLine("│ Código │ Produto                        │ Estoque  │");
            Console.WriteLine("├────────┼────────────────────────────────┼──────────┤");
            foreach (var p in _produtos)
            {
                Console.WriteLine($"│ {p.CodigoProduto,-6} │ {p.DescricaoProduto,-30} │ {p.Estoque,8} │");
            }
            Console.WriteLine("└────────┴────────────────────────────────┴──────────┘");
        }

        private void ExibirEstoqueAtual()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    ESTOQUE ATUAL                           ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            ExibirListaProdutos();
            AguardarTecla();
        }

        private void ExibirHistoricoMovimentacoes()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║               HISTÓRICO DE MOVIMENTAÇÕES                   ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            if (_movimentacoes.Count == 0)
            {
                Console.WriteLine("Nenhuma movimentação registrada.");
            }
            else
            {
                foreach (var mov in _movimentacoes)
                {
                    var produto = _produtos.FirstOrDefault(p => p.CodigoProduto == mov.CodigoProduto);
                    Console.WriteLine($"┌─ Movimentação #{mov.Id} ─────────────────────────────────────");
                    Console.WriteLine($"│  Tipo: {mov.TipoMovimentacao}");
                    Console.WriteLine($"│  Produto: {produto?.DescricaoProduto ?? "N/A"}");
                    Console.WriteLine($"│  Quantidade: {mov.Quantidade}");
                    Console.WriteLine($"│  Descrição: {mov.Descricao}");
                    Console.WriteLine($"│  Data: {mov.DataMovimentacao:dd/MM/yyyy HH:mm:ss}");
                    Console.WriteLine("└────────────────────────────────────────────────────────────");
                    Console.WriteLine();
                }
            }
            AguardarTecla();
        }

        private void AguardarTecla()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
