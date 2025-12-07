using System.Text.Json;
using DesafiosTarget.desafio_02.Application.Interfaces;
using DesafiosTarget.desafio_02.Domain.Entities;

namespace DesafiosTarget.desafio_02.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly string _caminhoArquivo;
    private List<Produto>? _produtos;

    public ProdutoRepository(string caminhoArquivo)
    {
        _caminhoArquivo = caminhoArquivo ?? throw new ArgumentNullException(nameof(caminhoArquivo));
    }

    public async Task<IEnumerable<Produto>> ObterTodosAsync()
    {
        await CarregarProdutosSeNecessarioAsync();
        return _produtos ?? Enumerable.Empty<Produto>();
    }

    public async Task<Produto?> ObterPorCodigoAsync(int codigo)
    {
        await CarregarProdutosSeNecessarioAsync();
        return _produtos?.FirstOrDefault(p => p.CodigoProduto == codigo);
    }

    private async Task CarregarProdutosSeNecessarioAsync()
    {
        if (_produtos != null)
            return;

        try
        {
            if (!File.Exists(_caminhoArquivo))
            {
                throw new FileNotFoundException($"Arquivo não encontrado: {_caminhoArquivo}");
            }

            var json = await File.ReadAllTextAsync(_caminhoArquivo);
            var dados = JsonSerializer.Deserialize<DadosEstoque>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            _produtos = dados?.Estoque ?? new List<Produto>();
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException($"Erro ao deserializar JSON: {ex.Message}", ex);
        }
    }
}

