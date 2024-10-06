using Microsoft.EntityFrameworkCore;
using UrbanFarming.Data.Mapping;
using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Data.Context
{
    public class UrbanContext : DbContext
    {
        public UrbanContext(DbContextOptions<UrbanContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            LoginMap.Map(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Login> Login { get; set; }
    }
}
