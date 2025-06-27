using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using NuGet.Versioning;
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

        // GET: api/Zapaz
        [HttpGet("Zapas")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapas()
        {
            return await _context.Zapas.ToListAsync();
        }

        // GET: api/Zapaz/5
        [HttpGet("Id")]
        public async Task<ActionResult<Zapa>> GetZapaId(int id)
        {
            var zapa = await _context.Zapas.FindAsync(id);
            if (zapa == null) return NotFound();
            return zapa;
        }

        [HttpGet("available")]
        public async Task<ActionResult<Zapa>> GetZapaAv(bool available)
        {
            var zapa = await _context.Zapas.Where(x=> x.Available == available).ToListAsync();
            if (zapa == null) return NotFound();
            return Ok(zapa);
        }

        [HttpGet("size")]
        public async Task<ActionResult<Zapa>> GetZapaSize(double size) 
        {
            var zapa = await _context.Zapas.Where(x => x.Size == size).ToListAsync();
            if (zapa == null) return NotFound();
            return Ok(zapa);
        }

        [HttpGet("color")]
        public async Task<ActionResult<Zapa>> GetZapaColor(string color)
        {
            var zapa = await _context.Zapas.Where(x => x.Color == color).ToListAsync();
            if (zapa == null) return NotFound();
            return Ok(zapa);
        }

        [HttpGet("sport")]
        public async Task<ActionResult<Zapa>> GetZapaSport(string sport)
        {
            var zapa = await _context.Zapas.Where(x => x.SportType == sport).ToListAsync();
            if (zapa == null) return NotFound();
            return Ok(zapa);
        }

        [HttpGet("brand")]
        public async Task<ActionResult<Zapa>> GetZapaBrand(string brand)
        {
            var zapa = await _context.Zapas.Where(x => x.Brand == brand).ToListAsync();
            if (zapa == null) return NotFound();
            return Ok(zapa);
            
        }

        [HttpGet("model")]
        public async Task<ActionResult<Zapa>> GetZapaModel(string model)
        {
            var zapa = await _context.Zapas.Where(x => x.Model.Contains(model) == true).ToListAsync();
            if (zapa == null) return NotFound();
            return Ok(zapa);

        }

        [HttpGet("genre")]
        public async Task<ActionResult<Zapa>> GetZapaGenre(string genre)
        {
            var zapa = await _context.Zapas.Where(x => x.Genre == genre || x.Genre == "Unisex").ToListAsync();
            if (zapa == null) return NotFound();
            return Ok(zapa);
        }

        [HttpGet("zapa")] /*--->>>> TRYING TO MAKE A GET ENDPOINT FOR SEARCHING WITH MULTIPLE PARAMETERS*/
        public async Task<ActionResult<Zapa>> GetCustomZapa(string filter)
        {
            //This still doesn´t filter the zapas correctly, but you can obtain specific zapas based on
            //your input. This not retrieve the best match although...
            var zapa = await _context.Zapas.Where(x =>
            filter.Contains(x.Brand) ||
            filter.Contains(x.Model) ||
            filter.Contains(x.Color) ||
            filter.Contains(x.Size.ToString()) ||
            filter.Contains(x.SportType) ||
            filter.Contains(x.Genre)).ToListAsync();
            if (zapa == null) return NotFound();
            return Ok(zapa);
        }

        // PUT: api/Zapaz/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("modify")]
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

        // POST: api/Zapaz
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("new-zapa")]
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

        // DELETE: api/Zapaz/5
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteZapa(int id)
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
