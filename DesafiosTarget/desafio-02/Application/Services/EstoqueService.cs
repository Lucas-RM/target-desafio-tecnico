using DesafiosTarget.desafio_02.Application.Interfaces;
using DesafiosTarget.desafio_02.Domain.Entities;

namespace DesafiosTarget.desafio_02.Application.Services;

public class EstoqueService : IEstoqueService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMovimentacaoRepository _movimentacaoRepository;
    private int _proximoIdMovimentacao = 1;

    public EstoqueService(
        IProdutoRepository produtoRepository,
        IMovimentacaoRepository movimentacaoRepository)
    {
        _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        _movimentacaoRepository = movimentacaoRepository ?? throw new ArgumentNullException(nameof(movimentacaoRepository));
    }

    public async Task<IEnumerable<Produto>> ObterProdutosAsync()
    {
        return await _produtoRepository.ObterTodosAsync();
    }

    public async Task<Produto?> ObterProdutoPorCodigoAsync(int codigo)
    {
        return await _produtoRepository.ObterPorCodigoAsync(codigo);
    }

    public async Task<Movimentacao> RegistrarEntradaAsync(int codigoProduto, int quantidade, string descricao)
    {
        var produto = await _produtoRepository.ObterPorCodigoAsync(codigoProduto);
        if (produto == null)
            throw new InvalidOperationException("Produto não encontrado");

        produto.AdicionarEstoque(quantidade);

        var movimentacao = CriarMovimentacao(codigoProduto, quantidade, descricao, TipoMovimentacao.Entrada);
        return await _movimentacaoRepository.AdicionarAsync(movimentacao);
    }

    public async Task<Movimentacao> RegistrarSaidaAsync(int codigoProduto, int quantidade, string descricao)
    {
        var produto = await _produtoRepository.ObterPorCodigoAsync(codigoProduto);
        if (produto == null)
            throw new InvalidOperationException("Produto não encontrado");

        produto.RemoverEstoque(quantidade);

        var movimentacao = CriarMovimentacao(codigoProduto, quantidade, descricao, TipoMovimentacao.Saida);
        return await _movimentacaoRepository.AdicionarAsync(movimentacao);
    }

    public async Task<IEnumerable<Movimentacao>> ObterHistoricoMovimentacoesAsync()
    {
        return await _movimentacaoRepository.ObterTodasAsync();
    }

    private Movimentacao CriarMovimentacao(int codigoProduto, int quantidade, string descricao, TipoMovimentacao tipo)
    {
        return new Movimentacao
        {
            Id = _proximoIdMovimentacao++,
            CodigoProduto = codigoProduto,
            Quantidade = quantidade,
            Descricao = descricao,
            TipoMovimentacao = tipo,
            DataMovimentacao = DateTime.Now
        };
    }
}

