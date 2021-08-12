using CarrinhoDeComprasApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using static System.Collections.Immutable.ImmutableArray<T>;

namespace CarrinhoDeComprasApi.Data.Builders
{
    public class PedidoBuilder : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            //Tabela
            builder.ToTable("Pedido");

            //PK
            builder.HasKey(p => p.Id);

            //Propiedades
            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(244)").IsRequired();
            builder.Property(p => p.Quantidade).HasColumnType("TEXT").IsRequired();
            builder.Property(p => p.Status).HasColumnType("VARCHAR(100)").IsRequired();

            //FK Cliente
            builder.HasIndex(e => e.IdCliente);
            builder.HasOne(d => d.Clientes)
                .WithMany(p => p.Pedido)
                .HasForeignKey(d => d.IdCliente);
        }
    }
}
