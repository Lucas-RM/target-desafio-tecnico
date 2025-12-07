using DesafiosTarget.desafio_02.Application.Interfaces;
using DesafiosTarget.desafio_02.Domain.Entities;

namespace DesafiosTarget.desafio_02.Infrastructure.Repositories;

public class MovimentacaoRepository : IMovimentacaoRepository
{
    private readonly List<Movimentacao> _movimentacoes = new();

    public Task<IEnumerable<Movimentacao>> ObterTodasAsync()
    {
        return Task.FromResult<IEnumerable<Movimentacao>>(_movimentacoes);
    }

    public Task<Movimentacao> AdicionarAsync(Movimentacao movimentacao)
    {
        if (movimentacao == null)
            throw new ArgumentNullException(nameof(movimentacao));

        _movimentacoes.Add(movimentacao);
        return Task.FromResult(movimentacao);
    }
}

