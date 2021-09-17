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
    [Route("api/v1/piloto")]
    [ApiController]
    public class PilotoController : ControllerBase
    {
        private readonly EstrelaDaMorteDbContext _context;

        public PilotoController(EstrelaDaMorteDbContext context)
        {
            _context = context;
        }

        // GET: api/Piloto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Piloto>>> GetPilotos()
        {
            return await _context.Pilotos.ToListAsync();
        }

        // GET: api/Piloto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Piloto>> GetPiloto(int id)
        {
            var piloto = await _context.Pilotos.FindAsync(id);

            if (piloto == null)
            {
                return NotFound();
            }

            return piloto;
        }

        // PUT: api/Piloto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiloto(int id, Piloto piloto)
        {
            if (id != piloto.IdPiloto)
            {
                return BadRequest();
            }

            _context.Entry(piloto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PilotoExists(id))
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

        // POST: api/Piloto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Piloto>> PostPiloto(Piloto piloto)
        {
            _context.Pilotos.Add(piloto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiloto", new { id = piloto.IdPiloto }, piloto);
        }

        // DELETE: api/Piloto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePiloto(int id)
        {
            var piloto = await _context.Pilotos.FindAsync(id);
            if (piloto == null)
            {
                return NotFound();
            }

            _context.Pilotos.Remove(piloto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PilotoExists(int id)
        {
            return _context.Pilotos.Any(e => e.IdPiloto == id);
        }
    }
}
