using DesafiosTarget.desafio_01.Application.Interfaces;
using DesafiosTarget.desafio_01.Domain.Entities;
using DesafiosTarget.desafio_01.Domain.ValueObjects;

namespace DesafiosTarget.desafio_01.Application.Services;

public class ComissaoService : IComissaoService
{
    private readonly IVendaRepository _vendaRepository;

    public ComissaoService(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository ?? throw new ArgumentNullException(nameof(vendaRepository));
    }

    public async Task<Dictionary<string, ComissaoVendedor>> CalcularComissoesAsync()
    {
        var vendas = await _vendaRepository.ObterTodasAsync();
        var comissoesPorVendedor = new Dictionary<string, ComissaoVendedor>();

        foreach (var venda in vendas)
        {
            ProcessarVenda(venda, comissoesPorVendedor);
        }

        return comissoesPorVendedor;
    }

    private static void ProcessarVenda(Venda venda, Dictionary<string, ComissaoVendedor> comissoesPorVendedor)
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

        var comissao = RegraComissao.Calcular(venda.Valor);
        var tipoComissao = RegraComissao.ObterTipo(venda.Valor);

        comissaoVendedor.TotalComissao += comissao;

        AtualizarContadoresPorTipo(comissaoVendedor, tipoComissao);
    }

    private static void AtualizarContadoresPorTipo(ComissaoVendedor comissaoVendedor, TipoComissao tipoComissao)
    {
        switch (tipoComissao)
        {
            case TipoComissao.SemComissao:
                comissaoVendedor.VendasSemComissao++;
                break;
            case TipoComissao.UmPorcento:
                comissaoVendedor.VendasComissao1Porcento++;
                break;
            case TipoComissao.CincoPorcento:
                comissaoVendedor.VendasComissao5Porcento++;
                break;
        }
    }
}

