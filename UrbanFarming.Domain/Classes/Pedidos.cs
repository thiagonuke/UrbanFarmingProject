namespace UrbanFarming.Domain.Classes
{
    public class Pedido
    {
        public int CodigoPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public string Usuario { get; set; }
        public DateTime Data { get; set; }

        public virtual ICollection<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
    }
}
