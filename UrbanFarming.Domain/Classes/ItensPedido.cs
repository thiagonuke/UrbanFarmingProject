namespace UrbanFarming.Domain.Classes
{
    public class ItemPedido
    {
        public int IdItem { get; set; }
        public int CodigoPedido { get; set; }
        public string NomeProduto { get; set; }
        public string CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}
