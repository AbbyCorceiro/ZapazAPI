using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZapazAPI.Context;
using ZapazAPI.Entities;
using ZapazAPI.Models;

namespace ZapazAPI.Repository
{
    public class ZapazRepository : IZapazRepo
    {
        private readonly ZapaDBContext _context;
        private readonly IConfiguration _configuration;
        public ZapazRepository(ZapaDBContext context, IConfiguration configuration) 
        { 
            _context = context; 
            _configuration = configuration;
        }

        public async Task<User?> Register(UserDto request)
        {
            if (await _context.Users.AnyAsync(u => u.PasswordHash == request.Password)) return null;
            var user = new User();
            var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);
            user.Username = request.Username;
            user.PasswordHash = hashedPassword;
            _context.Users.Add(user);  
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<string?> Login(UserDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if(user is null) return null;
            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password)
             == PasswordVerificationResult.Failed) return null;
            string token = CreateToken(user);
            return token;
        }

        //Creating the tokens :
        private string CreateToken(User user) 
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
            var key = new SymmetricSecurityKey
                (
                    Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:Key")!)
                );
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                    issuer: _configuration.GetValue<string>("Jwt:Issuer"),
                    audience: _configuration.GetValue<string>("Jwt:Audience"),
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
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

        //PUT    
        public async Task PutZapa(int id, Zapa zapa)
        {
            _context.Entry(zapa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return;
        }

        //POST 
        public async Task<Zapa> PostZapa(Zapa zapa)
        {
            _context.Zapas.Add(zapa);
            await _context.SaveChangesAsync();
            return zapa;
        }
            
        //DELETE
        public async Task DeleteZapa(int id)
        {
            var zapa = await _context.Zapas.FindAsync(id);
            if (zapa is not null) _context.Zapas.Remove(zapa);
            await _context.SaveChangesAsync();
            return;
        }
    }
}
