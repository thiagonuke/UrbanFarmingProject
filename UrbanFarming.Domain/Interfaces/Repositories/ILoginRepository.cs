using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Domain.Interfaces.Repositories
{
    public interface ILoginRepository
    {
        Task<Login> GetById(int id);
        Task<Login> GetByEmail(string email);
        Task<bool> PostUsuario(Login usuario);
    }
}
