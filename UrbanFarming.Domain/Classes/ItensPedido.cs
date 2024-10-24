using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanFarming.Domain.Classes
{
    public class ItemPedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int? IdItem { get; set; }
        public int? CodigoPedido { get; set; }
        public string? NomeProduto { get; set; }
        public string? CodigoProduto { get; set; }
        public int? Quantidade { get; set; }
        public decimal? ValorUnitario { get; set; }

    }
}
