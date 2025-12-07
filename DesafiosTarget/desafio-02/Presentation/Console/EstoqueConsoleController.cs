using DesafiosTarget.desafio_02.Application.Interfaces;
using DesafiosTarget.desafio_02.Domain.Entities;

namespace DesafiosTarget.desafio_02.Presentation.Console;

public class EstoqueConsoleController
{
    private readonly IEstoqueService _estoqueService;
    private readonly EstoqueConsoleView _view;

    public EstoqueConsoleController(IEstoqueService estoqueService, EstoqueConsoleView view)
    {
        _estoqueService = estoqueService ?? throw new ArgumentNullException(nameof(estoqueService));
        _view = view ?? throw new ArgumentNullException(nameof(view));
    }

    public async Task ExecutarAsync()
    {
        var produtos = await _estoqueService.ObterProdutosAsync();
        if (!produtos.Any())
        {
            System.Console.WriteLine("Nenhum produto encontrado no arquivo.");
            return;
        }

        bool continuar = true;
        while (continuar)
        {
            System.Console.Clear();
            _view.ExibirMenu();
            var opcao = System.Console.ReadLine();

            try
            {
                switch (opcao)
                {
                    case "1":
                        await ProcessarEntradaAsync();
                        _view.AguardarTecla();
                        break;
                    case "2":
                        await ProcessarSaidaAsync();
                        _view.AguardarTecla();
                        break;
                    case "3":
                        await ExibirEstoqueAsync();
                        break;
                    case "4":
                        await ExibirHistoricoAsync();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        System.Console.WriteLine("\nOpção inválida!");
                        Thread.Sleep(1000);
                        break;
                }
            }
            catch (Exception ex)
            {
                _view.ExibirErro(ex.Message);
                _view.AguardarTecla();
            }
        }
    }

    private async Task ProcessarEntradaAsync()
    {
        _view.ExibirCabecalhoMovimentacao(TipoMovimentacao.Entrada);
        var produtos = await _estoqueService.ObterProdutosAsync();
        _view.ExibirListaProdutos(produtos);

        var codigoProduto = LerCodigoProduto();
        if (codigoProduto == null)
            return;

        var quantidade = LerQuantidade();
        if (quantidade == null)
            return;

        var descricao = LerDescricao();
        if (string.IsNullOrWhiteSpace(descricao))
            return;

        var movimentacao = await _estoqueService.RegistrarEntradaAsync(codigoProduto.Value, quantidade.Value, descricao);
        var produto = await _estoqueService.ObterProdutoPorCodigoAsync(codigoProduto.Value);

        if (produto != null)
        {
            _view.ExibirResultadoMovimentacao(movimentacao, produto);
            _view.AguardarTecla();
        }
    }

    private async Task ProcessarSaidaAsync()
    {
        _view.ExibirCabecalhoMovimentacao(TipoMovimentacao.Saida);
        var produtos = await _estoqueService.ObterProdutosAsync();
        _view.ExibirListaProdutos(produtos);

        var codigoProduto = LerCodigoProduto();
        if (codigoProduto == null)
            return;

        var quantidade = LerQuantidade();
        if (quantidade == null)
            return;

        var descricao = LerDescricao();
        if (string.IsNullOrWhiteSpace(descricao))
            return;

        var movimentacao = await _estoqueService.RegistrarSaidaAsync(codigoProduto.Value, quantidade.Value, descricao);
        var produto = await _estoqueService.ObterProdutoPorCodigoAsync(codigoProduto.Value);

        if (produto != null)
        {
            _view.ExibirResultadoMovimentacao(movimentacao, produto);
            _view.AguardarTecla();
        }
    }

    private async Task ExibirEstoqueAsync()
    {
        var produtos = await _estoqueService.ObterProdutosAsync();
        _view.ExibirEstoqueAtual(produtos);
        _view.AguardarTecla();
    }

    private async Task ExibirHistoricoAsync()
    {
        var movimentacoes = await _estoqueService.ObterHistoricoMovimentacoesAsync();
        var produtos = await _estoqueService.ObterProdutosAsync();
        _view.ExibirHistoricoMovimentacoes(movimentacoes, produtos);
        _view.AguardarTecla();
    }

    private static int? LerCodigoProduto()
    {
        System.Console.Write("\nDigite o código do produto: ");
        if (!int.TryParse(System.Console.ReadLine(), out int codigo))
        {
            System.Console.WriteLine("Código inválido!");
            return null;
        }
        return codigo;
    }

    private static int? LerQuantidade()
    {
        System.Console.Write("Digite a quantidade: ");
        if (!int.TryParse(System.Console.ReadLine(), out int quantidade) || quantidade <= 0)
        {
            System.Console.WriteLine("Quantidade inválida!");
            return null;
        }
        return quantidade;
    }

    private static string LerDescricao()
    {
        System.Console.Write("Digite a descrição da movimentação: ");
        return System.Console.ReadLine() ?? string.Empty;
    }
}

