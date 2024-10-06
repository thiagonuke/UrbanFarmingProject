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

		public async Task<Usuario> EfetuarLogin(string username, string password) => await _httpClient.GetAsync($"").Result.Content.ReadFromJsonAsync<Usuario>();

	}
}
