using CarrinhoDeComprasApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoDeComprasApi.Data.Builders
{
    public class ProdutoBuilder : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            //Tabela
            builder.ToTable("Produto");

            //PK
            builder.HasKey(p => p.Id);

            //Propiedades
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(244)").IsRequired();
            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(244)").IsRequired();
            builder.Property(p => p.Foto).HasColumnType("TEXT").IsRequired();
            builder.Property(p => p.Tipo).HasColumnType("TEXT").IsRequired();

            //FK TipoProduto
            builder.HasIndex(e => e.IdTipoProduto);
            builder.HasOne(d => d.TipoProdutos)
                .WithMany(p => p.Produto)
                .HasForeignKey(d => d.IdTipoProduto);
        }
    }
}
