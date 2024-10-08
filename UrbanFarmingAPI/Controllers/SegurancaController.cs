﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrbanFarming.Domain.Classes;
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

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(Login usuario, [FromServices] ILoginService loginService)
            => Ok(await loginService.CadastrarUsuario(usuario));

        [HttpGet("Login")]
        public async Task<IActionResult> Login(string email, string senha, [FromServices] ILoginService loginService)
        {
            var (usuario, sucesso) = await loginService.Login(email, senha);

            if (!sucesso)
            {
                return Unauthorized(new { mensagem = "Credenciais inválidas." });
            }

            return Ok(new { usuario, sucesso });
        }

    }
}
