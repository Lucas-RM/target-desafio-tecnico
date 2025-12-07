namespace DesafiosTarget.desafio_01.Domain.ValueObjects;

public static class RegraComissao
{
    private const decimal LimiteSemComissao = 100m;
    private const decimal LimiteComissao1Porcento = 500m;
    private const decimal TaxaComissao1Porcento = 0.01m;
    private const decimal TaxaComissao5Porcento = 0.05m;

    public static decimal Calcular(decimal valorVenda)
    {
        if (valorVenda < LimiteSemComissao)
            return 0;

        if (valorVenda < LimiteComissao1Porcento)
            return valorVenda * TaxaComissao1Porcento;

        return valorVenda * TaxaComissao5Porcento;
    }

    public static TipoComissao ObterTipo(decimal valorVenda)
    {
        if (valorVenda < LimiteSemComissao)
            return TipoComissao.SemComissao;

        if (valorVenda < LimiteComissao1Porcento)
            return TipoComissao.UmPorcento;

        return TipoComissao.CincoPorcento;
    }
}

public enum TipoComissao
{
    SemComissao,
    UmPorcento,
    CincoPorcento
}

