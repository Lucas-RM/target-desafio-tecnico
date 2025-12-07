using DesafiosTarget.desafio_01.Domain.Entities;

namespace DesafiosTarget.desafio_01.Application.Interfaces;

public interface IVendaRepository
{
    Task<IEnumerable<Venda>> ObterTodasAsync();
}

