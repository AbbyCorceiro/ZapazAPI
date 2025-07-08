using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using ZapazAPI.Context;
using ZapazAPI.Controllers;
using ZapazAPI.Models;

namespace ZapazAPI.Services.ZapazService
{
    public class ZapazService : IZapazService
    {
        private readonly ZapaDBContext _context;
        public ZapazService(ZapaDBContext context)
        {
            _context = context;
        }

        //GET 
        //-all:
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapas()
        {
            return await _context.Zapas.ToListAsync();
        }

        //-by id:
        public async Task<ActionResult<Zapa>> GetZapaId(int id)
        {
            var zapa = await _context.Zapas.FindAsync(id);
            if (zapa == null) return new StatusCodeResult(404);
            return zapa;
        }

        //-by availability:
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaAv(bool available) 
        {
            var zapa = await _context.Zapas.Where(x => x.Available == available).ToListAsync();
            if (zapa == null) return new StatusCodeResult(404);
            return zapa;
        }

        //-by size:
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaSize(double size)
        {
            var zapa = await _context.Zapas.Where(x => x.Size == size).ToListAsync();
            if (zapa.IsNullOrEmpty()) return new StatusCodeResult(404);
            return zapa;
        }
        
        //-by color:
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaColor(string color)
        {
            var zapa = await _context.Zapas.Where(x => x.Color == color).ToListAsync();
            if (zapa.IsNullOrEmpty()) return new StatusCodeResult(404);
            return zapa;
        }

        //-by sport:
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaSport(string sport)
        {
            var zapa = await _context.Zapas.Where(x => x.SportType == sport).ToListAsync();
            if (zapa.IsNullOrEmpty()) return new StatusCodeResult(404);
            return zapa;
        }

        //-by brand:
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaBrand(string brand)
        {
            var zapa = await _context.Zapas.Where(x => x.Brand == brand).ToListAsync();
            if (zapa.IsNullOrEmpty()) return new StatusCodeResult(404);
            return zapa;
        }

        //-by model:
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaModel(string model)
        {
            var zapa = await _context.Zapas.Where(x => x.Model.Contains(model) == true).ToListAsync();
            if (zapa.IsNullOrEmpty()) return new StatusCodeResult(404);
            return zapa;
        }

        //-by genre:
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaGenre(string genre)
        {
            var zapa = await _context.Zapas.Where(x => x.Genre == genre).ToListAsync();
            if (zapa.IsNullOrEmpty()) return new StatusCodeResult(404);
            return zapa;
        }

        //-by custom filter:
        public async Task<ActionResult<IEnumerable<Zapa>>> GetCustomZapa(string filter)
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
            if (zapa.IsNullOrEmpty()) return new StatusCodeResult(404);
            return zapa;
        }

        //PUT 
        public async Task<IActionResult> PutZapa(int id, Zapa zapa)
        {
            if (id != zapa.Id) return new StatusCodeResult(400);

            _context.Entry(zapa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZapaExists(id)) return new StatusCodeResult(404);
                else throw;
            }
            return new StatusCodeResult(200); //Ok Status for modified c:
        }

        //POST 
        public async Task<ActionResult<Zapa>> PostZapa(Zapa zapa)
        {
            _context.Zapas.Add(zapa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ZapaExists(zapa.Id)) return new StatusCodeResult(409);
                else throw;
            }
            return new StatusCodeResult(201); //Retrieves a 201 code, but doesn´t retrieve the data and the header
            //Tried CreatedAtResult or similar methods with the 201 status code but doesn´t work yet--
        }

        //DELETE
        public async Task<IActionResult> DeleteZapa(int id)
        {
            var zapa = await _context.Zapas.FindAsync(id);
            if (zapa == null) return new StatusCodeResult(404);

            _context.Zapas.Remove(zapa);
            await _context.SaveChangesAsync();

            return new StatusCodeResult(204);
        }

        private bool ZapaExists(int id)
        {
            return _context.Zapas.Any(e => e.Id == id);
        }
    }
}
