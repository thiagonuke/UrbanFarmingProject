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
    }
}
