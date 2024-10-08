using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrbanFarming.Domain.Interfaces.Services;

namespace UrbanFarmingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurancaController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromServices] ILoginService loginService)
            => Ok(await loginService.GetById(id));

    }
}
