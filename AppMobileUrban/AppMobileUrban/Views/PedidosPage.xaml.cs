using AppMobileUrban.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;


namespace AppMobileUrban.Views
{
    public partial class PedidosPage : ContentPage
    {
        public PedidosPage()
        {
            InitializeComponent();
            BindingContext = new PedidosViewModel();
        }
    }
}