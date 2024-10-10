using Microsoft.AspNetCore.Mvc;
using UrbanFarming.Domain.Classes;
using UrbanFarmingWeb.UI.Request;
using UrbanFarmingWeb.UI.Util;

namespace UrbanFarmingWeb.UI.Controllers
{
    public class ProdutosController : Controller
    {

        private readonly RequestAPI _request;

        public ProdutosController(RequestAPI req)
        {
            _request = req;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.Get<User>("USER") != null)
            {
                ViewBag.Name = HttpContext.Session.Get<User>("USER").Nome;
            }

            var produtos = _request.ListaProdutos().Result;

            return View(produtos);
        }
    }
}
