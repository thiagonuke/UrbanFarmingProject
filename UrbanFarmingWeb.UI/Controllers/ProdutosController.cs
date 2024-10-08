using Microsoft.AspNetCore.Mvc;
using UrbanFarming.Domain.Classes;
using UrbanFarmingWeb.UI.Util;

namespace UrbanFarmingWeb.UI.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
