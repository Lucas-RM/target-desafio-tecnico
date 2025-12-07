using DesafiosTarget.desafio_03.Domain.ValueObjects;

namespace DesafiosTarget.desafio_03.Presentation.Console;

public class JurosConsoleView
{
    public void ExibirCabecalho()
    {
        System.Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        System.Console.WriteLine("║           CALCULADORA DE JUROS POR ATRASO                  ║");
        System.Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
        System.Console.WriteLine();
    }

    public void ExibirResultado(CalculoJuros calculo)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("════════════════════════════════════════════════════════════");
        System.Console.WriteLine($"  Data de Vencimento: {calculo.DataVencimento:dd/MM/yyyy}");
        System.Console.WriteLine($"  Data de Hoje:       {calculo.DataAtual:dd/MM/yyyy}");
        System.Console.WriteLine($"  Valor Original:     R$ {calculo.ValorOriginal:N2}");
        System.Console.WriteLine("════════════════════════════════════════════════════════════");

        if (calculo.EstaEmDia)
        {
            System.Console.WriteLine("  ✓ Não há atraso! O pagamento está em dia.");
            System.Console.WriteLine($"  Valor a Pagar:      R$ {calculo.ValorTotal:N2}");
        }
        else
        {
            var taxaPercentual = CalculoJuros.ObterTaxaMultaDiaria() * 100;
            System.Console.WriteLine($"  Dias de Atraso:     {calculo.DiasAtraso}");
            System.Console.WriteLine($"  Taxa de Multa:      {taxaPercentual:N1}% ao dia");
            System.Console.WriteLine($"  Valor dos Juros:    R$ {calculo.ValorJuros:N2}");
            System.Console.WriteLine($"  Valor Total:        R$ {calculo.ValorTotal:N2}");
        }

        System.Console.WriteLine("════════════════════════════════════════════════════════════");
    }

    public void ExibirErro(string mensagem)
    {
        System.Console.WriteLine($"Erro: {mensagem}");
    }
}

