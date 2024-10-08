using Microsoft.AspNetCore.Mvc;
using UrbanFarming.Domain.Classes;
using UrbanFarmingWeb.UI.Util;

namespace UrbanFarmingWeb.UI.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.Get<User>("USER") != null)
            {
                ViewBag.Name = HttpContext.Session.Get<User>("USER").Nome;
            }
            return View();
        }
    }
}
