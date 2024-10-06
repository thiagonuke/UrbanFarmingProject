using Microsoft.EntityFrameworkCore;
using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Data.Mapping
{
    public class LoginMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .ToTable("TB_MIT_BRINDE_LOG_ACESS");

            modelBuilder.Entity<Login>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Login>()
                .Property(x => x.Email)
                .HasColumnName("EMAIL");

            modelBuilder.Entity<Login>()
                .Property(x => x.Nome)
                .HasColumnName("SENHA");

            modelBuilder.Entity<Login>()
                .Property(x => x.Senha)
                .HasColumnName("NOME");
        }
    }
}
