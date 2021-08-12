using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoDeComprasApi.Models
{
    public class TipoProduto
    {
        //PK
        [Key]
        public long Id { get; set; }

        //Relação de 1 para muitos
        public ICollection<ProdutoPedido> ProdutoPedido { get; set; }

        //Relação de 1 para muitos
        public ICollection<Produto> Produto { get; set; }
    }
}
