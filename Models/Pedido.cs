using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoDeComprasApi.Models
{
    public class Pedido
    {
        //PK
        [Key]
        public long Id { get; set; }

        //Propiedades
        public string Descricao { get; set; }
        public string Quantidade { get; set; }
        public string Status { get; set; }

        //Relação de 1 para muitos
        public ICollection<ProdutoPedido> ProdutoPedido { get; set; }

        //ForeignKey
        [ForeignKey(nameof(Cliente))]
        public Cliente Clientes { get; set; }
        public long IdCliente { get; set; }
    }
}
