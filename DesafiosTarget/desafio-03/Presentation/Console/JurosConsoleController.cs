using DesafiosTarget.desafio_03.Application.Interfaces;
using DesafiosTarget.desafio_03.Domain.ValueObjects;

namespace DesafiosTarget.desafio_03.Presentation.Console;

public class JurosConsoleController
{
    private readonly IJurosService _jurosService;
    private readonly JurosConsoleView _view;

    public JurosConsoleController(IJurosService jurosService, JurosConsoleView view)
    {
        _jurosService = jurosService ?? throw new ArgumentNullException(nameof(jurosService));
        _view = view ?? throw new ArgumentNullException(nameof(view));
    }

    public void Executar()
    {
        _view.ExibirCabecalho();

        try
        {
            var valor = LerValor();
            var dataVencimento = LerDataVencimento();

            var calculo = _jurosService.CalcularJuros(valor, dataVencimento);
            _view.ExibirResultado(calculo);
        }
        catch (Exception ex)
        {
            _view.ExibirErro(ex.Message);
        }
    }

    private static decimal LerValor()
    {
        while (true)
        {
            System.Console.Write("Digite o valor original: R$ ");
            if (decimal.TryParse(System.Console.ReadLine(), out decimal valor) && valor > 0)
                return valor;
            System.Console.WriteLine("Valor inválido. Digite um número positivo.");
        }
    }

    private static DateTime LerDataVencimento()
    {
        while (true)
        {
            System.Console.Write("Digite a data de vencimento (dd/MM/yyyy): ");
            if (DateTime.TryParseExact(
                System.Console.ReadLine(),
                "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime data))
            {
                return data;
            }
            System.Console.WriteLine("Data inválida. Use o formato dd/MM/yyyy.");
        }
    }
}

