using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapas()
        {
            return await _context.Zapas.ToListAsync();
        }

        public async Task<ActionResult<Zapa>> GetZapaId(int id)
        {
            var zapa = await _context.Zapas.FindAsync(id);
            if (zapa == null) return new StatusCodeResult(404); //Find the way to retrieve a NotFound() code status
            return zapa;
        }

        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaAv(bool available) 
        {
            var zapa = await _context.Zapas.Where(x => x.Available == available).ToListAsync();
            if (zapa == null) return new StatusCodeResult(404);
            return zapa;
        }

        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaSize(double size)
        {
            var zapa = await _context.Zapas.Where(x => x.Size == size).ToListAsync();
            if (zapa == null) return new StatusCodeResult(404);
            return zapa;
        }
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaColor(string color)
        {
            var zapa = await _context.Zapas.Where(x => x.Color == color).ToListAsync();
            if (zapa == null) return new StatusCodeResult(404);
            return zapa;
        }

        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaSport(string sport)
        {
            var zapa = await _context.Zapas.Where(x => x.SportType == sport).ToListAsync();
            if (zapa == null) return new StatusCodeResult(404);
            return zapa;
        }

        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaBrand(string brand)
        {
            var zapa = await _context.Zapas.Where(x => x.Brand == brand).ToListAsync();
            if (zapa == null) return new StatusCodeResult(404);
            return zapa;
        }

        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaModel(string model)
        {
            var zapa = await _context.Zapas.Where(x => x.Model.Contains(model) == true).ToListAsync();
            if (zapa == null) return new StatusCodeResult(404);
            return zapa;

        }

        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaGenre(string genre)
        {
            /*Fix the result: if a search a kids zapa it retrieves one even if there´s no kids shoes in db
             under the filter 'kids', there's only male, female and unisex keywords*/
            var zapa = await _context.Zapas.Where(x => x.Genre == genre || x.Genre == "Unisex").ToListAsync();
            if (zapa == null) return new StatusCodeResult(404);
            return zapa;
        }

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
            if (zapa == null) return new StatusCodeResult(404);
            return zapa;
        }
    }
}
