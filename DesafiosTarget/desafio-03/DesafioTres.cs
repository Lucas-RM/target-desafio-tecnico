using System;

namespace DesafiosTarget.desafio_03
{
    public class DesafioTres
    {
        private const decimal TAXA_MULTA_DIARIA = 0.025m; // 2,5% ao dia

        public void Executar()
        {
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           CALCULADORA DE JUROS POR ATRASO                  ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            decimal valor = LerValor();
            DateTime dataVencimento = LerDataVencimento();

            CalcularEExibirJuros(valor, dataVencimento);
        }

        private decimal LerValor()
        {
            while (true)
            {
                Console.Write("Digite o valor original: R$ ");
                if (decimal.TryParse(Console.ReadLine(), out decimal valor) && valor > 0)
                    return valor;
                Console.WriteLine("Valor inválido. Digite um número positivo.");
            }
        }

        private DateTime LerDataVencimento()
        {
            while (true)
            {
                Console.Write("Digite a data de vencimento (dd/MM/yyyy): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", 
                    System.Globalization.CultureInfo.InvariantCulture, 
                    System.Globalization.DateTimeStyles.None, out DateTime data))
                    return data;
                Console.WriteLine("Data inválida. Use o formato dd/MM/yyyy.");
            }
        }

        private void CalcularEExibirJuros(decimal valor, DateTime dataVencimento)
        {
            DateTime hoje = DateTime.Today;
            int diasAtraso = (hoje - dataVencimento).Days;

            Console.WriteLine();
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine($"  Data de Vencimento: {dataVencimento:dd/MM/yyyy}");
            Console.WriteLine($"  Data de Hoje:       {hoje:dd/MM/yyyy}");
            Console.WriteLine($"  Valor Original:     R$ {valor:N2}");
            Console.WriteLine("════════════════════════════════════════════════════════════");

            if (diasAtraso <= 0)
            {
                Console.WriteLine("  ✓ Não há atraso! O pagamento está em dia.");
                Console.WriteLine($"  Valor a Pagar:      R$ {valor:N2}");
            }
            else
            {
                decimal juros = valor * TAXA_MULTA_DIARIA * diasAtraso;
                decimal valorTotal = valor + juros;

                Console.WriteLine($"  Dias de Atraso:     {diasAtraso}");
                Console.WriteLine($"  Taxa de Multa:      {TAXA_MULTA_DIARIA * 100:N1}% ao dia");
                Console.WriteLine($"  Valor dos Juros:    R$ {juros:N2}");
                Console.WriteLine($"  Valor Total:        R$ {valorTotal:N2}");
            }
            Console.WriteLine("════════════════════════════════════════════════════════════");
        }
    }
}
