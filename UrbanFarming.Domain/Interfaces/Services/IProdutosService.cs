using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Domain.Interfaces.Services
{
    public interface IProdutosService
    {
        Task<bool> CadastrarUsuario(Produtos usuario);
        Task<(Produtos usuario, bool sucesso)> Produtos(string email, string senha);
    }
}
