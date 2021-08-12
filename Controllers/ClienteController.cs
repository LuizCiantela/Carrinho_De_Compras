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
    public class ClienteController : ControllerBase
    {
        private readonly CarrinhoDeComprasContext _context;

        public ClienteController(CarrinhoDeComprasContext context)
        {
            _context = context;
        }

        // GET:
        // URI: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: 
        // URI: api/Cliente/5
        [HttpGet("GetCliente")]
        public async Task<ActionResult<Cliente>> GetCliente([FromBody] Cliente cliente)
        {
            var clientes = await _context.Clientes.FindAsync(cliente.Id);

            if (clientes == null)
            {
                return NotFound();
            }

            return clientes;
        }

        // PUT: Atualiza um Cliente.
        // URI: api/Cliente/5
        [HttpPut("PutCliente")]
        public async Task<IActionResult> PutCliente([FromBody] Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(cliente.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: Adiciona (posta) um Cliente.
        // URI: api/Cliente
        [HttpPost("PostCliente")]
        public async Task<ActionResult<Cliente>> PostCliente([FromBody] Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        // DELETE: Deleta o Cliente.
        // URI: api/Cliente/5
        [HttpDelete("DeleteCliente")]
        public async Task<ActionResult<Cliente>> DeleteCliente([FromBody] Cliente cliente)
        {
            var clientes = await _context.Clientes.FindAsync(cliente.Id);
            if (clientes == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();

            return clientes;
        }

        private bool ClienteExists(long id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
