using DesafiosTarget.desafio_03.Application.Interfaces;
using DesafiosTarget.desafio_03.Domain.ValueObjects;

namespace DesafiosTarget.desafio_03.Application.Services;

public class JurosService : IJurosService
{
    public CalculoJuros CalcularJuros(decimal valorOriginal, DateTime dataVencimento)
    {
        return new CalculoJuros(valorOriginal, dataVencimento);
    }
}

