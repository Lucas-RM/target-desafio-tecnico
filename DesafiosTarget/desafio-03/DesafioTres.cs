using DesafiosTarget.desafio_03.Application.Interfaces;
using DesafiosTarget.desafio_03.Application.Services;
using DesafiosTarget.desafio_03.Presentation.Console;

namespace DesafiosTarget.desafio_03;

public class DesafioTres
{
    private readonly JurosConsoleController _controller;

    public DesafioTres()
    {
        var jurosService = new JurosService();
        var view = new JurosConsoleView();
        _controller = new JurosConsoleController(jurosService, view);
    }

    public void Executar()
    {
        _controller.Executar();
    }
}
