namespace DesafiosTarget.desafio_02.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int CodigoProduto { get; set; }
        public string TipoMovimentacao { get; set; } = string.Empty; // "ENTRADA" ou "SAIDA"
        public int Quantidade { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }
}

