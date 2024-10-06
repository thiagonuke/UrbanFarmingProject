using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UrbanFarmingWeb.UI.Request;
using UrbanFarmingWeb.UI.Util;
using UrbanFarming.Domain.Classes;
using Microsoft.AspNetCore.Http;

namespace UrbanFarmingWeb.UI.Controllers
{
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

		public async Task<IActionResult> Login(string usuario, string senha)
		{
			string retorno = string.Empty;

			var dados = await _request.EfetuarLogin(usuario, senha);

			if (dados != null) {

				HttpContext.Session.Set<Usuario>("User", dados);

				retorno = "Success: Logado!";

			}
			else
			{
				retorno = "Usuario não encontrado!";
			}


			return Json(retorno);
		}


		
	}
 
}
