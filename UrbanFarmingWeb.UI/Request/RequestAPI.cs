using System.Net.Http.Json;
using UrbanFarming.Domain.Classes;

namespace UrbanFarmingWeb.UI.Request
{
	public class RequestAPI
	{
		private readonly HttpClient _httpClient;
		public RequestAPI(HttpClient httpClient) { 
		
			_httpClient = httpClient;

			_httpClient.BaseAddress = new Uri("https://localhost:44308");
		
		}

		public async Task<User> EfetuarLogin(string username, string password) => await _httpClient.GetAsync($"/api/Seguranca/Login?email={username}&senha={password}").Result.Content.ReadFromJsonAsync<User>();
		public async Task<HttpResponseMessage> EfetuarCadastrado(Login dados) => _httpClient.PostAsJsonAsync<Login>($"/api/Seguranca/CadastrarUsuario", dados).Result;
        public async Task<HttpResponseMessage> EfetuarCadastradoFornecedor(Fornecedores dados) => _httpClient.PostAsJsonAsync<Fornecedores>("/api/Fornecedores", dados).Result;
        public async Task<List<Produtos>> ListaProdutos()=> await _httpClient.GetAsync("/api/Produtos/GetAllProdutos").Result.Content.ReadFromJsonAsync<List<Produtos>>();
       
    }
}
