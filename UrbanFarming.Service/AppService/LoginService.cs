using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Exceptions;
using UrbanFarming.Domain.Interfaces.Repositories;
using UrbanFarming.Domain.Interfaces.Services;

namespace UrbanFarming.Service.AppService
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository clienteRepository)
        {
            _loginRepository = clienteRepository;
        }

        public async Task<Login> GetById(int id)
        {
            try
            {
                var usuario = new Login();

                usuario = await _loginRepository.GetById(id);

                if (usuario == null)
                    throw new NotFoundException("Usuário não encontrado");

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
