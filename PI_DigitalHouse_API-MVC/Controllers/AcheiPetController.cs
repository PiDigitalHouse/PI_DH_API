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
    public class AcheiPetController : ControllerBase
    {
        private readonly MeuPetContext _context;

        public AcheiPetController(MeuPetContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Listar todos os Pets encontrados
        /// </summary>
        /// <returns></returns>

        // GET: api/AcheiPet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcheiPet>>> GetAcheiPet()
        {
          if (_context.AcheiPet == null)
          {
              return NotFound();
          }
            return await _context.AcheiPet.ToListAsync();
        }

        /// <summary>
        /// Encontrar Pet pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         
        // GET: api/AcheiPet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcheiPet>> GetAcheiPet(int id)
        {
          if (_context.AcheiPet == null)
          {
              return NotFound();
          }
            var acheiPet = await _context.AcheiPet.FindAsync(id);

            if (acheiPet == null)
            {
                return NotFound();
            }

            return acheiPet;
        }

        /// <summary>
        /// Editar cadastro de Pet achado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="acheiPet"></param>
        /// <returns></returns>

        // PUT: api/AcheiPet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcheiPet(int id, AcheiPet acheiPet)
        {
            if (id != acheiPet.Id)
            {
                return BadRequest();
            }

            _context.Entry(acheiPet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcheiPetExists(id))
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
        /// Cadastrar  Pet achado
        /// </summary>
        /// <param name="acheiPet"></param>
        /// <returns></returns>
        /// <remarks>
        /// Exemplo Requisição:
        /// 
        ///     POST/ PET ACHADO
        ///     {
        ///        
        ///         "telefone": (79)9 1234 5678,
        ///         "tipoPet": "Dog",
        ///         "nomePet": "Paçoca",
        ///         "informações": "Encontrei na rua, próximo à praça, no bairro X ás 19H",
        ///         "endereco": "Bairro X, rua Y",
        ///         "numColeira": 54
        ///     }
        /// </remarks>

        // POST: api/AcheiPet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AcheiPet>> PostAcheiPet(AcheiPet acheiPet)
        {
          if (_context.AcheiPet == null)
          {
              return Problem("Entity set 'MeuPetContext.AcheiPet'  is null.");
          }
            _context.AcheiPet.Add(acheiPet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcheiPet", new { id = acheiPet.Id }, acheiPet);
        }

        /// <summary>
        /// Deletar Pet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // DELETE: api/AcheiPet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcheiPet(int id)
        {
            if (_context.AcheiPet == null)
            {
                return NotFound();
            }
            var acheiPet = await _context.AcheiPet.FindAsync(id);
            if (acheiPet == null)
            {
                return NotFound();
            }

            _context.AcheiPet.Remove(acheiPet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcheiPetExists(int id)
        {
            return (_context.AcheiPet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
