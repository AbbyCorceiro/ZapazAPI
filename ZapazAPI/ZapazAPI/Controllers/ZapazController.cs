using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IZapazService _zapazService;

        public ZapazController(IZapazService zapazService)
        {
            _zapazService = zapazService;
        }

        // GET: api/Zapaz
        [HttpGet("Zapas")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapas()
        {
            var result =  await _zapazService.GetZapas();
            return Ok(result);
        }

        // GET: api/Zapaz/5
        [HttpGet("Id")]
        public async Task<ActionResult<Zapa>> GetZapaId(int id)
        {
            var zapa =  await _zapazService.GetZapaId(id);
            if (zapa is null) return NotFound();
            return Ok(zapa);
        }

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaAv(bool available)
        {
            var result = await _zapazService.GetZapaAv(available);
            if (result is null || !result.Any()) return NotFound();
            return Ok(result);
        }

        [HttpGet("size")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaSize(double size) 
        {
            var zapa = await _zapazService.GetZapaSize(size);
            if (!zapa.Any()) return NotFound();
            return Ok(zapa);
        }

        [HttpGet("color")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaColor(string color)
        {
            var zapa = await _zapazService.GetZapaColor(color);
            if (!zapa.Any()) return NotFound();
            return Ok(zapa);
        }

        [HttpGet("sport")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaSport(string sport)
        {
            var zapa = await _zapazService.GetZapaSport(sport);
            if (!zapa.Any()) return NotFound();
            return Ok(zapa);
        }

        [HttpGet("brand")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaBrand(string brand)
        {
            var zapa = await _zapazService.GetZapaBrand(brand);
            if (!zapa.Any()) return NotFound();
            return Ok(zapa);
        }

        [HttpGet("model")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaModel(string model)
        {
            var zapa = await _zapazService.GetZapaModel(model);
            if (!zapa.Any()) return NotFound();
            return Ok(zapa);
        }

        [HttpGet("genre")]
        public async Task<ActionResult<IEnumerable<Zapa>>> GetZapaGenre(string genre)
        {
            var zapa = await _zapazService.GetZapaGenre(genre);
            if (!zapa.Any()) return NotFound();
            return Ok(zapa);
        }

        [HttpGet("zapa")] 
        public async Task<ActionResult<IEnumerable<Zapa>>> GetCustomZapa(string filter)
        {
            var zapa =  await _zapazService.GetCustomZapa(filter);
            if (!zapa.Any()) return NotFound();
            return Ok(zapa);
        }

        // PUT: api/Zapaz/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("modify")]
        public async Task<IActionResult> PutZapa(int id, Zapa zapa)
        {
            await _zapazService.PutZapa(id, zapa);
            if (zapa is null) return NotFound();
            if (zapa.Id != id) return BadRequest();
            return Ok(zapa);    
        }

        // POST: api/Zapaz
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("new-zapa")]
        public async Task<ActionResult<Zapa>> PostZapa(Zapa zapa)
        {
            await _zapazService.PostZapa(zapa);
            return Ok(zapa);
        }

        // DELETE: api/Zapaz/5
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteZapa(int id) 
        { 
            await _zapazService.DeleteZapa(id); 
            return Ok();
        }
    }
}
