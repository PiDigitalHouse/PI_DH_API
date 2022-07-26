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
    public class CadastroPetController : ControllerBase
    {
        private readonly MeuPetContext _context;

        public CadastroPetController(MeuPetContext context)
        {
            _context = context;
        }

        // GET: api/CadastroPet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CadastroPet>>> GetCadastroPets()
        {
          if (_context.CadastroPets == null)
          {
              return NotFound();
          }
            return await _context.CadastroPets.ToListAsync();
        }

        // GET: api/CadastroPet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CadastroPet>> GetCadastroPet(int id)
        {
          if (_context.CadastroPets == null)
          {
              return NotFound();
          }
            var cadastroPet = await _context.CadastroPets.FindAsync(id);

            if (cadastroPet == null)
            {
                return NotFound();
            }

            return cadastroPet;
        }

        // PUT: api/CadastroPet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadastroPet(int id, CadastroPet cadastroPet)
        {
            if (id != cadastroPet.Id)
            {
                return BadRequest();
            }

            _context.Entry(cadastroPet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadastroPetExists(id))
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

        // POST: api/CadastroPet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CadastroPet>> PostCadastroPet(CadastroPet cadastroPet)
        {
          if (_context.CadastroPets == null)
          {
              return Problem("Entity set 'MeuPetContext.CadastroPets'  is null.");
          }
            _context.CadastroPets.Add(cadastroPet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCadastroPet", new { id = cadastroPet.Id }, cadastroPet);
        }

        // DELETE: api/CadastroPet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCadastroPet(int id)
        {
            if (_context.CadastroPets == null)
            {
                return NotFound();
            }
            var cadastroPet = await _context.CadastroPets.FindAsync(id);
            if (cadastroPet == null)
            {
                return NotFound();
            }

            _context.CadastroPets.Remove(cadastroPet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CadastroPetExists(int id)
        {
            return (_context.CadastroPets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
