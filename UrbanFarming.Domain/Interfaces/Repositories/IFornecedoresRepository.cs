using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Domain.Interfaces.Repositories
{
    public interface IFornecedoresRepository
    {
        Task<Fornecedores> GetByCodigo(string codigo);
        Task<List<Fornecedores>> GetAllFornecedores();
        Task<bool> PostFornecedor(Fornecedores fornecedor);
        Task<bool> DeleteFornecedor(string codigo);
        Task<bool> PutFornecedor(Fornecedores fornecedor);
    }
}
