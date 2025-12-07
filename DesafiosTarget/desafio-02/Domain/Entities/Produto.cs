namespace DesafiosTarget.desafio_02.Domain.Entities;

public class Produto
{
    public int CodigoProduto { get; set; }
    public string DescricaoProduto { get; set; } = string.Empty;
    public int Estoque { get; set; }

    public void AdicionarEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("Quantidade deve ser maior que zero", nameof(quantidade));

        Estoque += quantidade;
    }

    public void RemoverEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("Quantidade deve ser maior que zero", nameof(quantidade));

        if (quantidade > Estoque)
            throw new InvalidOperationException($"Estoque insuficiente. Disponível: {Estoque}");

        Estoque -= quantidade;
    }
}

