using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using AppMobileUrban.Models;

namespace AppMobileUrban.Services
{
    public class requests
    {
        private const string Url = "http://10.0.2.2:5152";

        public async Task<Login> EfetuarLogin(string username, string password)
        {
            try
            {

                var client = new RestClient(Url);

                var request = new RestRequest($"/api/Seguranca/Login?email={username}&senha={password}", Method.GET);

                var response = await client.Execute(request);

                return JsonConvert.DeserializeObject<Login>(response.Content);


            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
