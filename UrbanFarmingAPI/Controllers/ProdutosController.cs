using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Interfaces.Services;

namespace UrbanFarmingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(Produtos usuario, [FromServices] IProdutosService ProdutosService)
            => Ok(await ProdutosService.CadastrarUsuario(usuario));

        [HttpGet("Produtos")]
        public async Task<IActionResult> Produtos(string email, string senha, [FromServices] IProdutosService ProdutosService)
        {
            var (usuario, sucesso) = await ProdutosService.Produtos(email, senha);

            if (!sucesso)
            {
                return Unauthorized(new { mensagem = "Credenciais inválidas." });
            }

            return Ok(new { usuario, sucesso });
        }
    }
}
