using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
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
        [HttpGet("Gets all the products")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapas()
        {
            return await _context.Zapas.ToListAsync();
        }

        // GET: api/Zapas/5
        [HttpGet("Gets all the products by id")]
        public async Task<ActionResult<Zapa>> GetZapaId(int id)
        {
            var zapa = await _context.Zapas.FindAsync(id);

            if (zapa == null)
            {
                return NotFound();
            }

            return zapa;
        }

        [HttpGet("Gets the available products")]
        public async Task<ActionResult<Zapa>> GetZapa(bool available)
        {
            var zapa = await _context.Zapas.FindAsync(available);
            if (zapa == null) return NotFound();
            return zapa;
        }

        [HttpGet("Gets the products by {size}")]
        public async Task<ActionResult<Zapa>> GetZapa(int size) 
        {
            var zapa = await _context.Zapas.FindAsync(size);
            if (zapa == null) return NotFound();
            return zapa;
        }

        [HttpGet("Gets the products by color")]
        public async Task<ActionResult<Zapa>> GetZapaColor(string color)
        {
            var zapa = await _context.Zapas.FindAsync(color);
            if (zapa == null) return NotFound();
            return zapa;
        }

        [HttpGet("Gets the products by sport type")]
        public async Task<ActionResult<Zapa>> GetZapaSport(string sport)
        {
            var zapa = await _context.Zapas.FindAsync(sport);
            if (zapa == null) return NotFound();
            return zapa;
        }

        [HttpGet("Gets the products by brand")]
        public async Task<ActionResult<Zapa>> GetZapa(string brand)
        {
            var zapa = await _context.Zapas.FindAsync(brand);
            if (zapa == null) return NotFound();
            return NotFound();
            
        }

        [HttpGet("Gets the products by genre")]
        public async Task<ActionResult<Zapa>> GetZapaGenre(string genre)
        {
            var zapa = await _context.Zapas.FindAsync(genre);
            if (zapa == null) return NotFound();
            return zapa;
        }
        // PUT: api/Zapas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Modifies an existing product by {id}")]
        public async Task<IActionResult> PutZapa(int id, Zapa zapa)
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
        [HttpPost("Creates a new item in the database (new zapa in the system)")]
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
        [HttpDelete("Deletes an existing product by {id}")]
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

        private bool ZapaExists(int id)
        {
            return _context.Zapas.Any(e => e.Id == id);
        }
    }
}
