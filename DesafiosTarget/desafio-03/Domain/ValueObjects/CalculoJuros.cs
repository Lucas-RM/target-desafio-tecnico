namespace DesafiosTarget.desafio_03.Domain.ValueObjects;

public class CalculoJuros
{
    private const decimal TaxaMultaDiaria = 0.025m; // 2,5% ao dia

    public decimal ValorOriginal { get; }
    public DateTime DataVencimento { get; }
    public DateTime DataAtual { get; }
    public int DiasAtraso { get; }
    public decimal ValorJuros { get; }
    public decimal ValorTotal { get; }
    public bool EstaEmDia => DiasAtraso <= 0;

    public CalculoJuros(decimal valorOriginal, DateTime dataVencimento, DateTime? dataAtual = null)
    {
        if (valorOriginal <= 0)
            throw new ArgumentException("Valor original deve ser maior que zero", nameof(valorOriginal));

        ValorOriginal = valorOriginal;
        DataVencimento = dataVencimento;
        DataAtual = dataAtual ?? DateTime.Today;
        DiasAtraso = (DataAtual - DataVencimento).Days;

        if (EstaEmDia)
        {
            ValorJuros = 0;
            ValorTotal = ValorOriginal;
        }
        else
        {
            ValorJuros = ValorOriginal * TaxaMultaDiaria * DiasAtraso;
            ValorTotal = ValorOriginal + ValorJuros;
        }
    }

    public static decimal ObterTaxaMultaDiaria() => TaxaMultaDiaria;
}

