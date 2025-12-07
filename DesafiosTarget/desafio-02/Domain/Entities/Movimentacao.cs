namespace DesafiosTarget.desafio_02.Domain.Entities;

public class Movimentacao
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public int CodigoProduto { get; set; }
    public TipoMovimentacao TipoMovimentacao { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataMovimentacao { get; set; }
}

public enum TipoMovimentacao
{
    Entrada,
    Saida
}

