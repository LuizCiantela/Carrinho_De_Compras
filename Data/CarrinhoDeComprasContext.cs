using CarrinhoDeComprasApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoDeComprasApi.Data
{
    public partial class CarrinhoDeComprasContext : DbContext
    {
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<ProdutoPedido> ProdutosPedidos { get; set; }
        public virtual DbSet<TipoProduto> TiposProdutos { get; set; }

        public CarrinhoDeComprasContext(DbContextOptions<CarrinhoDeComprasContext> options) : base(options)
        {
        }

        protected CarrinhoDeComprasContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("CarrinhoDeComprasDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarrinhoDeComprasContext).Assembly);
        }
    }
}
