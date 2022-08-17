using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PI_DigitalHouse_API_MVC.Models;
using PI_DigitalHouse_API_MVC.Services;

namespace PI_DigitalHouse_API_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]

    public class UsuarioController : ControllerBase
    {
        private readonly MeuPetContext _context;

        public UsuarioController(MeuPetContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("Autenticar")]
        [AllowAnonymous]
        public ActionResult<dynamic> Autenticar(Credencial credencial)
        {
            // 1. Buscar um usuário que tenha o mesmo email
            // e senha que a credencial.
            var usuario = _context.CadastroUsuarios.Where(Usuario => Usuario.Email == credencial.Email && Usuario.Senha == credencial.Senha).FirstOrDefault();

            // 2. Se usuário não for encontrado retorno email ou Senha incorretos.
            if (usuario == null)
            {
                return NotFound(new { menseger = "Email ou senha incorretos." });
            }
            else
            {
                // 3. Caso usuário seja encontrado...

                // 3.1. Gerar um Token.
                usuario.Senha = "";
                var chaveToken = TokenService.GerarChaveToken(usuario);

                // 3.2. Retorno o Token.
                return Ok(new { token = chaveToken });
            }
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
        /// <remarks>
        /// Exemplo requisição:
        /// 
        ///     POST /USUARIO
        ///     {
        ///           "nomeCompleto": "José Silva",
        ///           "email": "exemplo222@gmail.com",
        ///           "senha": "xaT@888##B",
        ///           "telefone": "79 9 88887777"
        ///      }     
        /// </remarks>

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
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
