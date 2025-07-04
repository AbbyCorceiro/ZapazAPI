using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZapazAPI.Context;
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
            //Once i got this working, i may implement the other endopoints as well :)
            var zapa = await _context.Zapas.FindAsync(id);
            if (zapa == null) return NotFound(); // Find the way to implement the method NotFound() in the service class
            return zapa;
        }
    }
}
