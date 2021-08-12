using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoDeComprasApi.DTOs
{
    //Uma DTO passa apenas o necessário (propiedades, geralmente) de uma model (não passa a Icollection, por exemplo).
    public class ClienteDTO
    {
        public long IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
