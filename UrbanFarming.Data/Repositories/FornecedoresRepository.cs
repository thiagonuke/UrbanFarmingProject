using Microsoft.EntityFrameworkCore;
using UrbanFarming.Data.Context;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Interfaces.Repositories;
using UrbanFarming.Repositories;

namespace UrbanFarming.Data.Repositories
{
    public class FornecedoresRepository : BaseRepository<Fornecedores>, IFornecedoresRepository
    {
        public FornecedoresRepository(UrbanContext context) : base(context)
        {

        }
        
        public async Task<Fornecedores> GetByCodigo(string codigo) 
        {
            try
            {
                return await _context.Fornecedores.FirstOrDefaultAsync(f => f.Codigo == codigo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<Fornecedores>> GetAllFornecedores()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        public async Task<bool> PostFornecedor(Fornecedores fornecedores)
        {
            try
            {
                await _context.Fornecedores.AddAsync(fornecedores);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<bool> DeleteFornecedor(string codigo)
        {
            try
            {
                var fornecedor = await _context.Fornecedores.FindAsync(codigo);

                if (fornecedor == null)
                    return false;

                _context.Fornecedores.Remove(fornecedor);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<bool> PutFornecedor(Fornecedores fornecedor)
        {
            try
            {
                var existingFornecedor = await _context.Fornecedores.FindAsync(fornecedor.Codigo);

                if (existingFornecedor == null)
                {
                    return false; 
                }

                existingFornecedor.Codigo = fornecedor.Codigo;
                existingFornecedor.RazaoSocial = fornecedor.RazaoSocial;
                existingFornecedor.NomeFantasia = fornecedor.NomeFantasia;
                existingFornecedor.CNPJ = fornecedor.CNPJ;
                existingFornecedor.PaisOrigem = fornecedor.PaisOrigem;
                existingFornecedor.Email = fornecedor.Email;
                existingFornecedor.EnquadramentoEstadual = fornecedor.EnquadramentoEstadual;
                existingFornecedor.RamoAtividade = fornecedor.RamoAtividade;
                existingFornecedor.PessoaJuridica = fornecedor.PessoaJuridica;
                existingFornecedor.PessoaFisica = fornecedor.PessoaFisica;
                await _context.SaveChangesAsync();

                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

    }
}
