using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business.Entities;
using Infra.Data;

namespace EstrelaDaMorteAPI.Controllers
{
    [Route("api/v1/nave")]
    [ApiController]
    public class NaveController : ControllerBase
    {
        private readonly EstrelaDaMorteDbContext _context;

        public NaveController(EstrelaDaMorteDbContext context)
        {
            _context = context;
        }

        // GET: api/Nave
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nave>>> GetNaves()
        {
            return await _context.Naves.ToListAsync();
        }

        // GET: api/Nave/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nave>> GetNave(int id)
        {
            var nave = await _context.Naves.FindAsync(id);

            if (nave == null)
            {
                return NotFound();
            }

            return nave;
        }

        // PUT: api/Nave/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNave(int id, Nave nave)
        {
            if (id != nave.IdNave)
            {
                return BadRequest();
            }

            _context.Entry(nave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaveExists(id))
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

        // POST: api/Nave
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nave>> PostNave(Nave nave)
        {
            _context.Naves.Add(nave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNave", new { id = nave.IdNave }, nave);
        }

        // DELETE: api/Nave/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNave(int id)
        {
            var nave = await _context.Naves.FindAsync(id);
            if (nave == null)
            {
                return NotFound();
            }

            _context.Naves.Remove(nave);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NaveExists(int id)
        {
            return _context.Naves.Any(e => e.IdNave == id);
        }
    }
}
