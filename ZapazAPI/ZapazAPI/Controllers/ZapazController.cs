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
using ZapazAPI.Services.ZapazService;

namespace ZapazAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZapazController : ControllerBase
    {
        private readonly ZapaDBContext _context;
        private readonly IZapazService _zapazService;

        public ZapazController(ZapaDBContext context, IZapazService zapazService)
        {
            _context = context;
            _zapazService = zapazService;
        }

        // GET: api/Zapaz
        [HttpGet("Zapas")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapas()
        {
            return await _zapazService.GetZapas();
        }

        // GET: api/Zapaz/5
        [HttpGet("Id")]
        public async Task<ActionResult<Zapa>> GetZapaId(int id)
        {
            return await _zapazService.GetZapaId(id);
        }

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaAv(bool available)
        {
            return await _zapazService.GetZapaAv(available);
        }

        [HttpGet("size")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaSize(double size) 
        {
            return await _zapazService.GetZapaSize(size);
        }

        [HttpGet("color")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaColor(string color)
        {
            return await _zapazService.GetZapaColor(color);
        }

        [HttpGet("sport")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaSport(string sport)
        {
            return await _zapazService.GetZapaSport(sport);
        }

        [HttpGet("brand")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaBrand(string brand)
        {
            return await _zapazService.GetZapaBrand(brand);
        }

        [HttpGet("model")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaModel(string model)
        {
            return await _zapazService.GetZapaModel(model);
        }

        [HttpGet("genre")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaGenre(string genre)
        {
            return await _zapazService.GetZapaGenre(genre);
        }

        [HttpGet("zapa")] 
        public async Task<ActionResult<IEnumerable<Zapa>>> GetCustomZapa(string filter)
        {
            return await _zapazService.GetCustomZapa(filter);
        }

        // PUT: api/Zapaz/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("modify")]
        public async Task<IActionResult> PutZapa(int id, Zapa zapa)
        {
            return await _zapazService.PutZapa(id, zapa);
        }

        // POST: api/Zapaz
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("new-zapa")]
        public async Task<ActionResult<Zapa>> PostZapa(Zapa zapa)
        {
           return await _zapazService.PostZapa(zapa);
        }

        // DELETE: api/Zapaz/5
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteZapa(int id)
        {
           return await _zapazService.DeleteZapa(id);
        }
    }
}
