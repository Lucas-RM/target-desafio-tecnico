using System.Text.Json;
using DesafiosTarget.desafio_01.Application.Interfaces;
using DesafiosTarget.desafio_01.Domain.Entities;

namespace DesafiosTarget.desafio_01.Infrastructure.Repositories;

public class VendaRepository : IVendaRepository
{
    private readonly string _caminhoArquivo;

    public VendaRepository(string caminhoArquivo)
    {
        _caminhoArquivo = caminhoArquivo ?? throw new ArgumentNullException(nameof(caminhoArquivo));
    }

    public async Task<IEnumerable<Venda>> ObterTodasAsync()
    {
        try
        {
            if (!File.Exists(_caminhoArquivo))
            {
                throw new FileNotFoundException($"Arquivo não encontrado: {_caminhoArquivo}");
            }

            var json = await File.ReadAllTextAsync(_caminhoArquivo);
            var dados = JsonSerializer.Deserialize<DadosVendas>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return dados?.Vendas ?? Enumerable.Empty<Venda>();
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException($"Erro ao deserializar JSON: {ex.Message}", ex);
        }
    }
}

