using Microsoft.AspNetCore.Mvc;
using UrbanFarming.Domain.Classes;
using UrbanFarmingWeb.UI.Request;
using UrbanFarmingWeb.UI.Util;

namespace UrbanFarmingWeb.UI.Controllers
{
	public class PedidosController : Controller
	{
        private readonly RequestAPI _request;

        public PedidosController(RequestAPI request) { 
        
        _request = request;
        
        }
        public IActionResult Index()
		{
            if (HttpContext.Session.Get<User>("USER") != null)
            {
                ViewBag.Name = HttpContext.Session.Get<User>("USER").Nome;
            }

            //var pedidos = _request.ListaPedidos().Result;


            return View();
		}

        [HttpPost]
        public IActionResult CadastrarPedidos([FromBody] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                var teste = _request.EfetuarCadastradoPedido(pedido).Result;

                return Ok("Pedido cadastrado com sucesso!");
            }
            return BadRequest("Erro ao cadastrar o pedido.");
        }

    }
}
