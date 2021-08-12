using CarrinhoDeComprasApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoDeComprasApi.Data.Builders
{
    public class ProdutoPedidoBuilder : IEntityTypeConfiguration<ProdutoPedido>
    {
        public void Configure(EntityTypeBuilder<ProdutoPedido> builder)
        {
            //Tabela
            builder.ToTable("ProdutoPedido");

            //PK
            builder.HasKey(p => p.Id);

            //FK Produto
            builder.HasIndex(e => e.IdProduto);
            builder.HasOne(d => d.Produtos)
                .WithMany(p => p.ProdutoPedido)
                .HasForeignKey(d => d.IdProduto);

            //FK Pedido
            builder.HasIndex(e => e.IdPedido);
            builder.HasOne(d => d.Pedidos)
                .WithMany(p => p.ProdutoPedido)
                .HasForeignKey(d => d.IdPedido);
        }
    }
}
