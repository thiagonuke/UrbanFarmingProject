using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UrbanFarmingWeb.UI.Request;
using UrbanFarmingWeb.UI.Util;
using UrbanFarming.Domain.Classes;
using Microsoft.AspNetCore.Http;

namespace UrbanFarmingWeb.UI.Controllers
{
	[Route("[controller]")]
	public class SegurancaController : Controller
	{
		private readonly RequestAPI _request;

		public SegurancaController(RequestAPI req) 
		{
			_request = req;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] User dadosT)
		{
			string retorno = string.Empty;

			var dados = await _request.EfetuarLogin(dadosT.Email, dadosT.Senha);

			if (dados != null) {

				dados = new User()
				{
					Id = 12,
					Nome = "Thiago",
					Email = "mthiag@gmail.com",
					Senha = ""
				};

				HttpContext.Session.Set<User>("User", dados);

				retorno = "Success: Logado!";

			}
			else
			{
				retorno = "Usuario não encontrado!";
			}

			return Json(retorno);
		}

		private void Logout() => HttpContext.Session.Remove("User");
		
	}
 
}
