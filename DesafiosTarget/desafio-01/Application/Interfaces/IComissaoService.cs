using DesafiosTarget.desafio_01.Domain.Entities;

namespace DesafiosTarget.desafio_01.Application.Interfaces;

public interface IComissaoService
{
    Task<Dictionary<string, ComissaoVendedor>> CalcularComissoesAsync();
}

