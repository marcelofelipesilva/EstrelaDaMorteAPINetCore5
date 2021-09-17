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
    [Route("api/v1/planeta")]
    [ApiController]
    public class PlanetaController : ControllerBase
    {
        private readonly EstrelaDaMorteDbContext _context;

        public PlanetaController(EstrelaDaMorteDbContext context)
        {
            _context = context;
        }

        // GET: api/Planeta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planeta>>> GetPlanetas()
        {
            return await _context.Planetas.ToListAsync();
        }

        // GET: api/Planeta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Planeta>> GetPlaneta(int id)
        {
            var planeta = await _context.Planetas.FindAsync(id);

            if (planeta == null)
            {
                return NotFound();
            }

            return planeta;
        }

        // PUT: api/Planeta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaneta(int id, Planeta planeta)
        {
            if (id != planeta.IdPlaneta)
            {
                return BadRequest();
            }

            _context.Entry(planeta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanetaExists(id))
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

        // POST: api/Planeta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Planeta>> PostPlaneta(Planeta planeta)
        {
            _context.Planetas.Add(planeta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaneta", new { id = planeta.IdPlaneta }, planeta);
        }

        // DELETE: api/Planeta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaneta(int id)
        {
            var planeta = await _context.Planetas.FindAsync(id);
            if (planeta == null)
            {
                return NotFound();
            }

            _context.Planetas.Remove(planeta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanetaExists(int id)
        {
            return _context.Planetas.Any(e => e.IdPlaneta == id);
        }
    }
}
