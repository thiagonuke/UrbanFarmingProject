using AppMobileUrban.Models;
using AppMobileUrban.Views;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

namespace AppMobileUrban.ViewModels
{
    public class ItemsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Produtos> _items;

        private string _name;

        private const string Url = "http://10.0.2.2:5152";

        public ObservableCollection<Produtos> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public ItemsViewModel()
        {
            Items = new ObservableCollection<Produtos>();
            LoadItems();
        }

        private async void LoadItems()
        {
            var client = new RestClient(Url);

            var request = new RestRequest($"/api/Produtos/GetAllProdutos", Method.Get);

            var response = client.Execute(request);

            var items = JsonConvert.DeserializeObject<List<Produtos>>(response.Content);

            foreach (var item in items)
            {
                Items.Add(item);
            }

            if (Application.Current.Properties.ContainsKey("Nome"))
            {
                Name = Application.Current.Properties["Nome"] as string;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}