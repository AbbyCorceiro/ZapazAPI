using Microsoft.AspNetCore.Mvc;
using ZapazAPI.Models;

namespace ZapazAPI.Services.ZapazService
{
    public interface IZapazService
    {
        public Task<ActionResult<IEnumerable<Zapa>>> GetZapas();
        public Task<ActionResult<Zapa>> GetZapaId(int id);
    }
}
