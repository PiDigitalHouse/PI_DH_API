using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PI_DigitalHouse_API_MVC.Models;

namespace PI_DigitalHouse_API_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroUsuarioController : ControllerBase
    {
        private readonly MeuPetContext _context;

        public CadastroUsuarioController(MeuPetContext context)
        {
            _context = context;
        }

        // GET: api/CadastroUsuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CadastroUsuario>>> GetCadastroUsuarios()
        {
          if (_context.CadastroUsuarios == null)
          {
              return NotFound();
          }
            return await _context.CadastroUsuarios.ToListAsync();
        }

        // GET: api/CadastroUsuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CadastroUsuario>> GetCadastroUsuario(int id)
        {
          if (_context.CadastroUsuarios == null)
          {
              return NotFound();
          }
            var cadastroUsuario = await _context.CadastroUsuarios.FindAsync(id);

            if (cadastroUsuario == null)
            {
                return NotFound();
            }

            return cadastroUsuario;
        }

        // PUT: api/CadastroUsuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadastroUsuario(int id, CadastroUsuario cadastroUser)
        {
            if (id != cadastroUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(cadastroUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadastroUsuarioExists(id))
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

        // POST: api/CadastroUsuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CadastroUsuario>> PostCadastroUsuario(CadastroUsuario cadastroUsuario)
        {
          if (_context.CadastroUsuarios == null)
          {
              return Problem("Entity set 'MeuPetContext.CadastroUsuarios'  is null.");
          }
            _context.CadastroUsuarios.Add(cadastroUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCadastroUsuario", new { id = cadastroUsuario.Id }, cadastroUsuario);
        }

        // DELETE: api/CadastroUsuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCadastroUsuario(int id)
        {
            if (_context.CadastroUsuarios == null)
            {
                return NotFound();
            }
            var cadastroUsuario = await _context.CadastroUsuarios.FindAsync(id);
            if (cadastroUsuario == null)
            {
                return NotFound();
            }

            _context.CadastroUsuarios.Remove(cadastroUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CadastroUsuarioExists(int id)
        {
            return (_context.CadastroUsuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
