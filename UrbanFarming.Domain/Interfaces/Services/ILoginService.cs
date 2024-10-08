using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Domain.Interfaces.Services
{
    public interface ILoginService
    {
        Task<Login> GetById(int id);
        Task<bool> CadastrarUsuario(Login usuario);
        Task<(Login usuario, bool sucesso)> Login(string email, string senha);
    }
}
