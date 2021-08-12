using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoDeComprasApi.Models
{
    public class ProdutoPedido
    {
        //PK
        [Key]
        public long Id { get; set; }

        //ForeignKey
        [ForeignKey(nameof(Produto))]
        public Produto Produtos { get; set; }
        public long IdProduto { get; set; }

        [ForeignKey(nameof(Pedido))]
        public Pedido Pedidos { get; set; }
        public long IdPedido { get; set; }
    }
}
