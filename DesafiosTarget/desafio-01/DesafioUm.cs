using DesafiosTarget.desafio_01.Application.Interfaces;
using DesafiosTarget.desafio_01.Application.Services;
using DesafiosTarget.desafio_01.Infrastructure.Repositories;
using DesafiosTarget.desafio_01.Presentation.Console;

namespace DesafiosTarget.desafio_01;

public class DesafioUm
{
    private readonly IComissaoService _comissaoService;
    private readonly ComissaoConsoleView _view;

    public DesafioUm()
    {
        var caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "desafio-01", "registros-vendas.json");
        var vendaRepository = new VendaRepository(caminhoArquivo);
        _comissaoService = new ComissaoService(vendaRepository);
        _view = new ComissaoConsoleView();
    }

    public async Task ExecutarAsync()
    {
        _view.ExibirCabecalho();

        try
        {
            var comissoesPorVendedor = await _comissaoService.CalcularComissoesAsync();

            if (comissoesPorVendedor.Count == 0)
            {
                System.Console.WriteLine("Nenhuma venda encontrada no arquivo.");
                return;
            }

            _view.ExibirResultados(comissoesPorVendedor);
        }
        catch (Exception ex)
        {
            _view.ExibirErro(ex.Message);
        }
    }

    public void Executar()
    {
        ExecutarAsync().GetAwaiter().GetResult();
    }
}
