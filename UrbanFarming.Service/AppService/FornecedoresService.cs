using System.Security.Cryptography;
using System.Text;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Exceptions;
using UrbanFarming.Domain.Interfaces.Repositories;
using UrbanFarming.Domain.Interfaces.Services;

namespace UrbanFarming.Service.AppService
{
    public class FornecedoresService : IFornecedoresService
    {
        private readonly IFornecedoresRepository _fornecedoresRepository;

        public FornecedoresService(IFornecedoresRepository fornecedoresRepository)
        {
            _fornecedoresRepository = fornecedoresRepository;
        }

        public async Task<Fornecedores> GetByCodigo(string codigo)
        {
            var fornecedor = await _fornecedoresRepository.GetByCodigo(codigo);
            if (fornecedor == null)
            {
                throw new NotFoundException("Fornecedor não encontrado.");
            }
            return fornecedor;
        }

        public async Task<List<Fornecedores>> GetAllFornecedores()
        {
            return await _fornecedoresRepository.GetAllFornecedores();
        }

        public async Task<bool> PostFornecedor(Fornecedores fornecedor)
        {
            var sucesso = await _fornecedoresRepository.PostFornecedor(fornecedor);

            if (!sucesso)
                throw new Exception("Não foi possível cadastrar o fornecedor.");

            return sucesso;
        }

        public async Task<bool> PutFornecedor(Fornecedores fornecedor)
        {
            var existingFornecedor = await _fornecedoresRepository.GetByCodigo(fornecedor.Codigo);
            if (existingFornecedor == null)
            {
                throw new NotFoundException("Produto não encontrado.");
            }

            return await _fornecedoresRepository.PutFornecedor(fornecedor);
        }

        public async Task<bool> DeleteFornecedor(string codigo)
        {
            var existingFornecedor = await _fornecedoresRepository.GetByCodigo(codigo);
            if (existingFornecedor == null)
            {
                throw new NotFoundException("Produto não encontrado.");
            }

            return await _fornecedoresRepository.DeleteFornecedor(codigo);
        }
    }
}
