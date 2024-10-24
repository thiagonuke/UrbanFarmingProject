using AppMobileUrban.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppMobileUrban.ViewModels
{
    public class PedidosViewModel
    {
        public ObservableCollection<Pedido> Pedidos { get; set; }

        public PedidosViewModel()
        {
            Pedidos = new ObservableCollection<Pedido>
            {
                new Pedido { CodigoPedido = 1, ValorTotal = 100.00m, Usuario = "João", Data = DateTime.Now },
                new Pedido { CodigoPedido = 2, ValorTotal = 150.50m, Usuario = "Maria", Data = DateTime.Now.AddDays(-1) },
                new Pedido { CodigoPedido = 3, ValorTotal = 200.75m, Usuario = "Carlos", Data = DateTime.Now.AddDays(-2) }
            };
        }
    }
}
