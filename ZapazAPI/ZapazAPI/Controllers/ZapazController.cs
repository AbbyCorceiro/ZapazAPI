using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZapazAPI.Context;
using ZapazAPI.Models;

namespace ZapazAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZapazController : ControllerBase
    {
        private readonly ZapaDBContext _context;

        public ZapazController(ZapaDBContext context)
        {
            _context = context;
        }

        // GET: api/Zapas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapas()
        {
            return await _context.Zapas.ToListAsync();
        }

        // GET: api/Zapas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zapa>> GetZapa(string id)
        {
            var zapa = await _context.Zapas.FindAsync(id);

            if (zapa == null)
            {
                return NotFound();
            }

            return zapa;
        }

        // PUT: api/Zapas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZapa(string id, Zapa zapa)
        {
            if (id != zapa.Id)
            {
                return BadRequest();
            }

            _context.Entry(zapa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZapaExists(id))
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

        // POST: api/Zapas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Zapa>> PostZapa(Zapa zapa)
        {
            _context.Zapas.Add(zapa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ZapaExists(zapa.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetZapa", new { id = zapa.Id }, zapa);
        }

        // DELETE: api/Zapas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZapa(string id)
        {
            var zapa = await _context.Zapas.FindAsync(id);
            if (zapa == null)
            {
                return NotFound();
            }

            _context.Zapas.Remove(zapa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZapaExists(string id)
        {
            return _context.Zapas.Any(e => e.Id == id);
        }
    }
}
