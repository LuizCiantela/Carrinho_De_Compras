using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoDeComprasApi.Models
{
    public class Cliente : Usuario
    {
        //PK
        [Key]
        public long Id { get; set; }

        //Relação de 1 para muitos
        public ICollection<Pedido> Pedido { get; set; }
    }
}
