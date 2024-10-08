﻿using Microsoft.EntityFrameworkCore;
using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Data.Mapping
{
    public class FornecedoresMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedores>()
                .ToTable("Fornecedores");

            modelBuilder.Entity<Fornecedores>()
                .HasKey(p => p.Codigo);

            modelBuilder.Entity<Fornecedores>()
                .Property(p => p.Codigo)
                .HasColumnName("Codigo")
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Fornecedores>()
                .Property(x => x.RazaoSocial)
                .HasColumnName("RazaoSocial")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Fornecedores>()
                .Property(x => x.NomeFantasia)
                .HasColumnName("NomeFantasia")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Fornecedores>()
                .Property(x => x.CNPJ)
                .HasColumnName("CNPJ")
                .IsRequired()
                .HasMaxLength(14);

            modelBuilder.Entity<Fornecedores>()
                .Property(x => x.PaisOrigem)
                .HasColumnName("PaisOrigem")
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Fornecedores>()
                .Property(x => x.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Fornecedores>()
                .Property(x => x.EnquadramentoEstadual)
                .HasColumnName("EnquadramentoEstadual")
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Fornecedores>()
                .Property(x => x.RamoAtividade)
                .HasColumnName("RamoAtividade")
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Fornecedores>()
                .Property(x => x.PessoaJuridica)
                .HasColumnName("PessoaJuridica")
                .IsRequired();

            modelBuilder.Entity<Fornecedores>()
                .Property(x => x.PessoaFisica)
                .HasColumnName("PessoaFisica")
                .IsRequired();
        }
    }
}
