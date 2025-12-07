using DesafiosTarget.desafio_02.Domain.Entities;

namespace DesafiosTarget.desafio_02.Presentation.Console;

public class EstoqueConsoleView
{
    public void ExibirMenu()
    {
        System.Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        System.Console.WriteLine("║           CONTROLE DE MOVIMENTAÇÃO DE ESTOQUE              ║");
        System.Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
        System.Console.WriteLine("║   [1] Entrada de Mercadoria                                ║");
        System.Console.WriteLine("║   [2] Saída de Mercadoria                                  ║");
        System.Console.WriteLine("║   [3] Consultar Estoque Atual                              ║");
        System.Console.WriteLine("║   [4] Histórico de Movimentações                           ║");
        System.Console.WriteLine("║   [0] Voltar ao Menu Principal                             ║");
        System.Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
        System.Console.Write("\nEscolha uma opção: ");
    }

    public void ExibirListaProdutos(IEnumerable<Produto> produtos)
    {
        System.Console.WriteLine("┌────────┬────────────────────────────────┬──────────┐");
        System.Console.WriteLine("│ Código │ Produto                        │ Estoque  │");
        System.Console.WriteLine("├────────┼────────────────────────────────┼──────────┤");
        foreach (var produto in produtos)
        {
            System.Console.WriteLine($"│ {produto.CodigoProduto,-6} │ {produto.DescricaoProduto,-30} │ {produto.Estoque,8} │");
        }
        System.Console.WriteLine("└────────┴────────────────────────────────┴──────────┘");
    }

    public void ExibirCabecalhoMovimentacao(TipoMovimentacao tipo)
    {
        System.Console.Clear();
        System.Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        var titulo = tipo == TipoMovimentacao.Entrada ? "ENTRADA" : "  SAÍDA";
        System.Console.WriteLine($"║             {titulo} DE MERCADORIA                          ║");
        System.Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
        System.Console.WriteLine();
    }

    public void ExibirResultadoMovimentacao(Movimentacao movimentacao, Produto produto)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        System.Console.WriteLine("║              MOVIMENTAÇÃO REALIZADA COM SUCESSO            ║");
        System.Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
        System.Console.WriteLine($"║  ID Movimentação: {movimentacao.Id,-40} ║");
        System.Console.WriteLine($"║  Tipo: {movimentacao.TipoMovimentacao,-51} ║");
        System.Console.WriteLine($"║  Produto: {produto.DescricaoProduto,-48} ║");
        System.Console.WriteLine($"║  Quantidade: {movimentacao.Quantidade,-45} ║");
        System.Console.WriteLine($"║  Descrição: {movimentacao.Descricao,-46} ║");
        System.Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
        System.Console.WriteLine($"║  ESTOQUE FINAL: {produto.Estoque,-42} ║");
        System.Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
    }

    public void ExibirEstoqueAtual(IEnumerable<Produto> produtos)
    {
        System.Console.Clear();
        System.Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        System.Console.WriteLine("║                    ESTOQUE ATUAL                           ║");
        System.Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
        System.Console.WriteLine();
        ExibirListaProdutos(produtos);
    }

    public void ExibirHistoricoMovimentacoes(IEnumerable<Movimentacao> movimentacoes, IEnumerable<Produto> produtos)
    {
        System.Console.Clear();
        System.Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        System.Console.WriteLine("║               HISTÓRICO DE MOVIMENTAÇÕES                   ║");
        System.Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
        System.Console.WriteLine();

        var movimentacoesList = movimentacoes.ToList();
        if (movimentacoesList.Count == 0)
        {
            System.Console.WriteLine("Nenhuma movimentação registrada.");
        }
        else
        {
            var produtosDict = produtos.ToDictionary(p => p.CodigoProduto);

            foreach (var movimentacao in movimentacoesList)
            {
                var produto = produtosDict.GetValueOrDefault(movimentacao.CodigoProduto);
                ExibirDetalhesMovimentacao(movimentacao, produto);
            }
        }
    }

    public void ExibirErro(string mensagem)
    {
        System.Console.WriteLine($"\nErro: {mensagem}");
    }

    public void AguardarTecla()
    {
        System.Console.WriteLine("\nPressione qualquer tecla para continuar...");
        System.Console.ReadKey();
    }

    private static void ExibirDetalhesMovimentacao(Movimentacao movimentacao, Produto? produto)
    {
        System.Console.WriteLine($"┌─ Movimentação #{movimentacao.Id} ─────────────────────────────────────");
        System.Console.WriteLine($"│  Tipo: {movimentacao.TipoMovimentacao}");
        System.Console.WriteLine($"│  Produto: {produto?.DescricaoProduto ?? "N/A"}");
        System.Console.WriteLine($"│  Quantidade: {movimentacao.Quantidade}");
        System.Console.WriteLine($"│  Descrição: {movimentacao.Descricao}");
        System.Console.WriteLine($"│  Data: {movimentacao.DataMovimentacao:dd/MM/yyyy HH:mm:ss}");
        System.Console.WriteLine("└────────────────────────────────────────────────────────────");
        System.Console.WriteLine();
    }
}

