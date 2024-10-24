using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanFarming.Domain.Classes
{
    public class Pedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoPedido { get; set; }
        public decimal? ValorTotal { get; set; }
        public string? Usuario { get; set; }
        public DateTime? Data { get; set; }
        public new List<ItemPedido> Itens { get; set; } 


        public Pedido() { 
        
            Itens = new List<ItemPedido>();

        }
    }
}
