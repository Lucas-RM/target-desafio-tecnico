using DesafiosTarget.desafio_01.Domain.Entities;

namespace DesafiosTarget.desafio_01.Presentation.Console;

public class ComissaoConsoleView
{
    public void ExibirCabecalho()
    {
        System.Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        System.Console.WriteLine("║         CALCULADORA DE COMISSÕES - TIME COMERCIAL          ║");
        System.Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
        System.Console.WriteLine("║  Regras de Comissão:                                       ║");
        System.Console.WriteLine("║  • Vendas < R$100,00  → Sem comissão                       ║");
        System.Console.WriteLine("║  • Vendas < R$500,00  → 1% de comissão                     ║");
        System.Console.WriteLine("║  • Vendas >= R$500,00 → 5% de comissão                     ║");
        System.Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
        System.Console.WriteLine();
    }

    public void ExibirResultados(Dictionary<string, ComissaoVendedor> comissoesPorVendedor)
    {
        System.Console.WriteLine("┌────────────────────────────────────────────────────────────┐");
        System.Console.WriteLine("│                   RELATÓRIO DE COMISSÕES                   │");
        System.Console.WriteLine("└────────────────────────────────────────────────────────────┘");
        System.Console.WriteLine();

        decimal totalGeralComissoes = 0;
        decimal totalGeralVendas = 0;

        foreach (var item in comissoesPorVendedor.OrderByDescending(x => x.Value.TotalComissao))
        {
            var vendedor = item.Value;
            totalGeralComissoes += vendedor.TotalComissao;
            totalGeralVendas += vendedor.TotalVendas;

            ExibirDetalhesVendedor(vendedor);
        }

        ExibirResumoGeral(totalGeralVendas, totalGeralComissoes);
    }

    public void ExibirErro(string mensagem)
    {
        System.Console.WriteLine($"Erro: {mensagem}");
    }

    private static void ExibirDetalhesVendedor(ComissaoVendedor vendedor)
    {
        System.Console.WriteLine($"┌─ {vendedor.Nome} ─────────────────────────────────────────────");
        System.Console.WriteLine($"│  Total de Vendas:      {vendedor.QuantidadeVendas} vendas");
        System.Console.WriteLine($"│  Valor Total:          {vendedor.TotalVendas:C}");
        System.Console.WriteLine($"│  ");
        System.Console.WriteLine($"│  Detalhamento:");
        System.Console.WriteLine($"│    • Vendas sem comissão (<R$100):    {vendedor.VendasSemComissao}");
        System.Console.WriteLine($"│    • Vendas com 1% (<R$500):          {vendedor.VendasComissao1Porcento}");
        System.Console.WriteLine($"│    • Vendas com 5% (>=R$500):         {vendedor.VendasComissao5Porcento}");
        System.Console.WriteLine($"│  ");
        System.Console.WriteLine($"│  - COMISSÃO TOTAL: {vendedor.TotalComissao:C}");
        System.Console.WriteLine($"└────────────────────────────────────────────────────────────");
        System.Console.WriteLine();
    }

    private static void ExibirResumoGeral(decimal totalGeralVendas, decimal totalGeralComissoes)
    {
        System.Console.WriteLine("╔════════════════════════════════════════════════════════════");
        System.Console.WriteLine($"║  RESUMO GERAL                                             ");
        System.Console.WriteLine($"║  Total de Vendas da Equipe: {totalGeralVendas,25:C}");
        System.Console.WriteLine($"║  Total de Comissões:        {totalGeralComissoes,25:C}");
        System.Console.WriteLine("╚════════════════════════════════════════════════════════════");
    }
}

