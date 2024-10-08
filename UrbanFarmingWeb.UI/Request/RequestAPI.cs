using UrbanFarming.Domain.Classes;

namespace UrbanFarmingWeb.UI.Request
{
	public class RequestAPI
	{
		private readonly HttpClient _httpClient;
		public RequestAPI(HttpClient httpClient) { 
		
			_httpClient = httpClient;

			_httpClient.BaseAddress = new Uri("https://localhost:7191");
		
		}

		public async Task<User> EfetuarLogin(string username, string password) => await _httpClient.GetAsync($"/api/Seguranca/").Result.Content.ReadFromJsonAsync<User>();

	}
}
