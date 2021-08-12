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
    public class FuncionarioController : ControllerBase
    {
        private readonly CarrinhoDeComprasContext _context;

        public FuncionarioController(CarrinhoDeComprasContext context)
        {
            _context = context;
        }

        // GET: api/Funcionario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarios()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        // GET: api/Funcionario/5
        [HttpGet("GetFuncionario")]
        public async Task<ActionResult<Funcionario>> GetFuncionario([FromBody] Funcionario funcionario)
        {
            var funcionarios = await _context.Funcionarios.FindAsync(funcionario.Id);

            if (funcionarios == null)
            {
                return NotFound();
            }

            return funcionarios;
        }

        // PUT: api/Funcionario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("PutFuncionario")]
        public async Task<IActionResult> PutFuncionario([FromBody] Funcionario funcionario)
        {
            _context.Entry(funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(funcionario.Id))
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

        // POST: api/Funcionario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("PostFuncionario")]
        public async Task<ActionResult<Funcionario>> PostFuncionario([FromBody] Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncionario", new { id = funcionario.Id }, funcionario);
        }

        // DELETE: api/Funcionario/5
        [HttpDelete("DeleteFuncionario")]
        public async Task<ActionResult<Funcionario>> DeleteFuncionario([FromBody] Funcionario funcionario)
        {
            var funcionarios = await _context.Funcionarios.FindAsync(funcionario.Id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionarios);
            await _context.SaveChangesAsync();

            return funcionarios;
        }

        private bool FuncionarioExists(long id)
        {
            return _context.Funcionarios.Any(e => e.Id == id);
        }
    }
}
