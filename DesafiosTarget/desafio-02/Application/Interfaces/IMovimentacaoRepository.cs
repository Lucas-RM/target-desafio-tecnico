using DesafiosTarget.desafio_02.Domain.Entities;

namespace DesafiosTarget.desafio_02.Application.Interfaces;

public interface IMovimentacaoRepository
{
    Task<IEnumerable<Movimentacao>> ObterTodasAsync();
    Task<Movimentacao> AdicionarAsync(Movimentacao movimentacao);
}

