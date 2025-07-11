using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZapazAPI.Context;
using ZapazAPI.Models;

namespace ZapazAPI.Repository
{
    public class ZapazRepository : IZapazRepo
    {
        private readonly ZapaDBContext _context;

        public ZapazRepository(ZapaDBContext context)
        { 
            _context = context;
        }
        //GET 
        //-all:
        public async Task<IEnumerable<Zapa>> GetZapas()
        {
            return await _context.Zapas.ToListAsync();
        }

        //-by id:
        public async Task<Zapa?> GetZapaId(int id)
        {
            return await _context.Zapas.FindAsync(id);
        }

        //-by availability:
        public async Task<IEnumerable<Zapa>> GetZapaAv(bool available)
        {
            return await _context.Zapas.Where(x => x.Available == available).ToListAsync();
        }

        //-by size:
        public async Task<IEnumerable<Zapa>> GetZapaSize(double size)
        {
            return await _context.Zapas.Where(x => x.Size == size).ToListAsync();
        }

        //-by color:
        public async Task<IEnumerable<Zapa>> GetZapaColor(string color)
        {
            return await _context.Zapas.Where(x => x.Color == color).ToListAsync();
        }

        //-by sport:
        public async Task<IEnumerable<Zapa>> GetZapaSport(string sport)
        {
            return await _context.Zapas.Where(x => x.SportType == sport).ToListAsync();
        }

        //-by brand:
        public async Task<IEnumerable<Zapa>> GetZapaBrand(string brand)
        {
            return await _context.Zapas.Where(x => x.Brand == brand).ToListAsync();
        }

        //-by model:
        public async Task<IEnumerable<Zapa>> GetZapaModel(string model)
        {
            return await _context.Zapas.Where(x => x.Model.Contains(model) == true).ToListAsync();
        }

        //-by genre:
        public async Task<IEnumerable<Zapa>> GetZapaGenre(string genre)
        {
            return await _context.Zapas.Where(x => x.Genre == genre).ToListAsync();
        }

        //-by custom filter:
        public async Task<IEnumerable<Zapa>> GetCustomZapa(string filter)
        {
            //This still doesn´t filter the zapas correctly, but you can obtain specific zapas based on
            //your input. This not retrieve the best match although...
            return await _context.Zapas.Where(x =>
            filter.Contains(x.Brand) ||
            filter.Contains(x.Model) ||
            filter.Contains(x.Color) ||
            filter.Contains(x.Size.ToString()) ||
            filter.Contains(x.SportType) ||
            filter.Contains(x.Genre)).ToListAsync();
        }

        //PUT       ---TO FIX
        public async Task PutZapa(int id, Zapa zapa)
        {
            _context.Entry(zapa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return;
        }

        //POST ---TO FIX
        public async Task<Zapa> PostZapa(Zapa zapa)
        {
            _context.Zapas.Add(zapa);
            await _context.SaveChangesAsync();
            return zapa;
        }
            
        //DELETE ---TO FIX
        public async Task DeleteZapa(int id)
        {
            var zapa = await _context.Zapas.FindAsync(id);
            if (zapa is not null) _context.Zapas.Remove(zapa);
            await _context.SaveChangesAsync();
            return;
        }
    }
}
