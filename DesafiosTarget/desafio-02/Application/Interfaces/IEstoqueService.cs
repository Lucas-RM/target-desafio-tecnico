using DesafiosTarget.desafio_02.Domain.Entities;

namespace DesafiosTarget.desafio_02.Application.Interfaces;

public interface IEstoqueService
{
    Task<IEnumerable<Produto>> ObterProdutosAsync();
    Task<Produto?> ObterProdutoPorCodigoAsync(int codigo);
    Task<Movimentacao> RegistrarEntradaAsync(int codigoProduto, int quantidade, string descricao);
    Task<Movimentacao> RegistrarSaidaAsync(int codigoProduto, int quantidade, string descricao);
    Task<IEnumerable<Movimentacao>> ObterHistoricoMovimentacoesAsync();
}

