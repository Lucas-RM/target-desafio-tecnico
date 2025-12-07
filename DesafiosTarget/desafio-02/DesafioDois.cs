using DesafiosTarget.desafio_02.Application.Interfaces;
using DesafiosTarget.desafio_02.Application.Services;
using DesafiosTarget.desafio_02.Infrastructure.Repositories;
using DesafiosTarget.desafio_02.Presentation.Console;

namespace DesafiosTarget.desafio_02;

public class DesafioDois
{
    private readonly EstoqueConsoleController _controller;

    public DesafioDois()
    {
        var caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "desafio-02", "estoque-dos-produtos.json");
        var produtoRepository = new ProdutoRepository(caminhoArquivo);
        var movimentacaoRepository = new MovimentacaoRepository();
        var estoqueService = new EstoqueService(produtoRepository, movimentacaoRepository);
        var view = new EstoqueConsoleView();
        _controller = new EstoqueConsoleController(estoqueService, view);
    }

    public async Task ExecutarAsync()
    {
        await _controller.ExecutarAsync();
    }

    public void Executar()
    {
        ExecutarAsync().GetAwaiter().GetResult();
    }
}
