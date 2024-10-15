using Microsoft.AspNetCore.Mvc;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Exceptions;
using UrbanFarming.Domain.Interfaces.Services;

namespace UrbanFarmingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _PedidosService;

        public PedidosController(IPedidosService PedidosService)
        {
            _PedidosService = PedidosService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarProduto([FromBody] Pedidos produto)
        {
            if (produto == null)
            {
                return BadRequest(new { mensagem = "Produto inválido." });
            }

            var sucesso = await _PedidosService.PostProduto(produto);

            if (!sucesso)
            {
                return BadRequest(new { mensagem = "Não foi possível cadastrar o produto." });
            }

            return Ok(new { mensagem = "Produto cadastrado com sucesso." });
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetByCodigo(string codigo)
        {
            try
            {
                var produto = await _PedidosService.GetByCodigo(codigo);
                return Ok(produto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpGet("GetAllPedidos")]
        public async Task<IActionResult> GetAllPedidos()
        {
            var Pedidos = await _PedidosService.GetAllPedidos();
            return Ok(Pedidos);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduto([FromBody] Pedidos produto)
        {
            if (produto == null || string.IsNullOrWhiteSpace(produto.Codigo))
            {
                return BadRequest(new { mensagem = "Produto inválido." });
            }

            var sucesso = await _PedidosService.PutProduto(produto);

            if (!sucesso)
            {
                return NotFound(new { mensagem = "Produto não encontrado." });
            }

            return Ok(new { mensagem = "Produto atualizado com sucesso." });
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteProduto(string codigo)
        {
            var sucesso = await _PedidosService.DeleteProduto(codigo);

            if (!sucesso)
            {
                return NotFound(new { mensagem = "Produto não encontrado." });
            }

            return Ok(new { mensagem = "Produto deletado com sucesso." });
        }
    }
}