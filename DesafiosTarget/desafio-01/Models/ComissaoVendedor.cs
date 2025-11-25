namespace DesafiosTarget.desafio_01.Models
{
    public class ComissaoVendedor
    {
        public string Nome { get; set; } = string.Empty;
        public decimal TotalVendas { get; set; }
        public decimal TotalComissao { get; set; }
        public int QuantidadeVendas { get; set; }
        public int VendasSemComissao { get; set; }
        public int VendasComissao1Porcento { get; set; }
        public int VendasComissao5Porcento { get; set; }
    }
}
