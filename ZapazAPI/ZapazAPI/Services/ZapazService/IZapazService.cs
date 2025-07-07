using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZapazAPI.Models;

namespace ZapazAPI.Services.ZapazService
{
    public interface IZapazService
    {
        //GET 
        public Task<ActionResult<IEnumerable<Zapa>>> GetZapas();
        public Task<ActionResult<Zapa>> GetZapaId(int id);
        public Task<ActionResult<IEnumerable<Zapa>>> GetZapaAv(bool available);
        public Task<ActionResult<IEnumerable<Zapa>>> GetZapaSize(double size);
        public Task<ActionResult<IEnumerable<Zapa>>> GetZapaColor(string color);
        public Task<ActionResult<IEnumerable<Zapa>>> GetZapaSport(string sport);
        public Task<ActionResult<IEnumerable<Zapa>>> GetZapaBrand(string brand);
        public Task<ActionResult<IEnumerable<Zapa>>> GetZapaModel(string model);
        public Task<ActionResult<IEnumerable<Zapa>>> GetZapaGenre(string genre);
        public Task<ActionResult<IEnumerable<Zapa>>> GetCustomZapa(string filter);

        //PUT 
        public Task<IActionResult> PutZapa(int id, Zapa zapa);

        //POST 
        public Task<ActionResult<Zapa>> PostZapa(Zapa zapa);

        //DELETE 
        public Task<IActionResult> DeleteZapa(int id);
    }
}
