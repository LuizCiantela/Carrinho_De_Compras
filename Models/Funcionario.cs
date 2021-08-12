using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoDeComprasApi.Models
{
    public class Funcionario : Usuario
    {
        //PK
        [Key]
        public long Id { get; set; }
    }
}
