using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoDeComprasApi.Models
{
    public class Produto
    {
        //PK
        [Key]
        public long Id { get; set; }

        //Propiedades
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public string Tipo { get; set; }
        //public string FuncionarioInserindo { get; set; }

        //Relação de 1 para muitos
        public ICollection<ProdutoPedido> ProdutoPedido { get; set; }

        //ForeignKey
        [ForeignKey(nameof(TipoProduto))]
        public TipoProduto TipoProdutos { get; set; }
        public long IdTipoProduto { get; set; }
    }
}
