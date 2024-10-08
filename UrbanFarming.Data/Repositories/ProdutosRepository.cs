using Microsoft.EntityFrameworkCore;
using UrbanFarming.Data.Context;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Interfaces.Repositories;
using UrbanFarming.Repositories;

namespace UrbanFarming.Data.Repositories
{
    public class ProdutosRepository : BaseRepository<Produtos>, IProdutosRepository
    {
        public ProdutosRepository(UrbanContext context) : base(context)
        {

        }
        
        public async Task<Produtos> GetByEmail(string email) 
        {
            try
            {
                return await _context.Produtos.FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<bool> PostUsuario(Produtos usuario)
        {
            try
            {
                await _context.Produtos.AddAsync(usuario);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
    }
}
