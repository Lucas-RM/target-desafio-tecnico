using DesafiosTarget.desafio_02.Domain.Entities;

namespace DesafiosTarget.desafio_02.Application.Interfaces;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> ObterTodosAsync();
    Task<Produto?> ObterPorCodigoAsync(int codigo);
}

