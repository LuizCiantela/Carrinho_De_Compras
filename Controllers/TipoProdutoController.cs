using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarrinhoDeComprasApi.Data;
using CarrinhoDeComprasApi.Models;

namespace CarrinhoDeComprasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProdutoController : ControllerBase
    {
        private readonly CarrinhoDeComprasContext _context;

        public TipoProdutoController(CarrinhoDeComprasContext context)
        {
            _context = context;
        }

        // GET: Lista todos os tipos de produtos da lista TipoProduto.
        // URI: api/TipoProduto
        [HttpGet]

        //TEM Q AJEITAR AINDA EM
        public async Task<ActionResult<IEnumerable<TipoProduto>>> GetTiposProdutos()
        {
            return await _context.TiposProdutos.ToListAsync();
        }
    }
}
