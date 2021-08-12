using CarrinhoDeComprasApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoDeComprasApi.Data.Builders
{
    public class ClienteBuilder : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //Tabela
            builder.ToTable("Clientes");

            //PK
            builder.HasKey(p => p.Id);

            //Propiedades
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(244)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("VARCHAR(244)").IsRequired();
            builder.Property(p => p.Senha).HasColumnType("VARCHAR(244)").IsRequired();
        }
    }
}
