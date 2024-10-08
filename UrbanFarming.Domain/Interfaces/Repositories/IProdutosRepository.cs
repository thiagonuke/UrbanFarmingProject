using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Domain.Interfaces.Repositories
{
    public interface IProdutosRepository
    {
        Task<Produtos> GetByEmail(string email);
        Task<bool> PostUsuario(Produtos usuario);
    }
}
