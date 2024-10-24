using System;

namespace AppMobileUrban.Models
{
    public class Pedido
    {
        public int CodigoPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public string Usuario { get; set; }
        public DateTime Data { get; set; }
    }
}
