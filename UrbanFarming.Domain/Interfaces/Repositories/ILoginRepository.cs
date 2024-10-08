using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Domain.Interfaces.Repositories
{
    public interface ILoginRepository
    {
        Task<Login> GetByEmail(string email);
        Task<bool> PostUsuario(Login usuario);
    }
}
