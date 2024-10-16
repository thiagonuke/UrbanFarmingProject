using Microsoft.EntityFrameworkCore;
using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Data.Mapping
{
    public class ItensPedidoMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemPedido>()
                .ToTable("ItensPedido");

            modelBuilder.Entity<ItemPedido>()
                .HasKey(i => i.IdItem);

            modelBuilder.Entity<ItemPedido>()
                .Property(i => i.IdItem)
                .HasColumnName("IdItem")
                .IsRequired();

            modelBuilder.Entity<ItemPedido>()
                .Property(i => i.CodigoPedido)
                .HasColumnName("CodigoPedido")
                .IsRequired();

            modelBuilder.Entity<ItemPedido>()
                .Property(i => i.NomeProduto)
                .HasColumnName("NomeProduto")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<ItemPedido>()
                .Property(i => i.CodigoProduto)
                .HasColumnName("CodigoProduto")
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<ItemPedido>()
                .Property(i => i.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();

            modelBuilder.Entity<ItemPedido>()
                .Property(i => i.ValorUnitario)
                .HasColumnName("ValorUnitario")
                .IsRequired()
                .HasColumnType("decimal(10, 2)");
        }
    }
}
