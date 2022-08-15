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
    public class UsuarioController : ControllerBase
    {
        private readonly MeuPetContext _context;

        public UsuarioController(MeuPetContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Listar todos os usuários cadastrados
        /// </summary>
        /// <returns></returns>

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetCadastroUsuarios()
        {
          if (_context.CadastroUsuarios == null)
          {
              return NotFound();
          }
            return await _context.CadastroUsuarios.ToListAsync();
        }

        /// <summary>
        /// Encontrar usuário pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         
        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetCadastroUsuario(int id)
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


        /// <summary>
        /// Editar cadastro de usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cadastroUser"></param>
        /// <returns></returns>
     
        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadastroUsuario(int id, Usuario cadastroUser)
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

        /// <summary>
        /// Cadastrar um usuário
        /// </summary>
        /// <param name="cadastroUsuario"></param>
        /// <returns></returns>

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostCadastroUsuario(Usuario cadastroUsuario)
        {
          if (_context.CadastroUsuarios == null)
          {
              return Problem("Entity set 'MeuPetContext.CadastroUsuarios'  is null.");
          }
            _context.CadastroUsuarios.Add(cadastroUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCadastroUsuario", new { id = cadastroUsuario.Id }, cadastroUsuario);
        }


        /// <summary>
        /// Deletar usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       
        // DELETE: api/Usuario/5
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
