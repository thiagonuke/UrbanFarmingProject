using Microsoft.EntityFrameworkCore;
using UrbanFarming.Data.Context;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Interfaces.Repositories;
using UrbanFarming.Repositories;

namespace UrbanFarming.Data.Repositories
{
    public class LoginRepository : BaseRepository<Login>, ILoginRepository
    {
        public LoginRepository(UrbanContext context) : base(context)
        {

        }

        public async Task<Login> GetById(int id)
        {
            var usuario = await _context.Login.FirstOrDefaultAsync(u => u.Id == id);
            return usuario;
        }
    }
}
