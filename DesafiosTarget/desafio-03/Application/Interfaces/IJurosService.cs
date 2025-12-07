using DesafiosTarget.desafio_03.Domain.ValueObjects;

namespace DesafiosTarget.desafio_03.Application.Interfaces;

public interface IJurosService
{
    CalculoJuros CalcularJuros(decimal valorOriginal, DateTime dataVencimento);
}

