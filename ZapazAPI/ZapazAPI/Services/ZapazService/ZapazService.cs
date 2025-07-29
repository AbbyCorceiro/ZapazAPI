using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Runtime.CompilerServices;
using ZapazAPI.Context;
using ZapazAPI.Controllers;
using ZapazAPI.Entities;
using ZapazAPI.Models;
using ZapazAPI.Repository;

namespace ZapazAPI.Services.ZapazService
{
    public class ZapazService : IZapazService
    {
        private readonly IZapazRepo _zapazRepo;
        public ZapazService(IZapazRepo zapazRepo)
        {
            _zapazRepo = zapazRepo;
        }

        public async Task<User?> RegisterAsync(UserDto request)
        {
            return await _zapazRepo.Register(request);
        }

        public async Task<string?> LoginAsync(UserDto request) 
        {
            return await _zapazRepo.Login(request);
        }

        //GET 
        //-all:
        public async Task<IEnumerable<Zapa>> GetZapas()
        {
            return await _zapazRepo.GetZapas();
        }

        //-by id:
        public async Task<Zapa?> GetZapaId(int id)
        {
            return await _zapazRepo.GetZapaId(id);
        }

        //-by availability:
        public async Task<IEnumerable<Zapa>> GetZapaAv(bool available) 
        {
           return await _zapazRepo.GetZapaAv(available);
        }

        //-by size:
        public async Task<IEnumerable<Zapa>> GetZapaSize(double size)
        {
            return await _zapazRepo.GetZapaSize(size);
        }
        
        //-by color:
        public async Task<IEnumerable<Zapa>> GetZapaColor(string color)
        {
            return await _zapazRepo.GetZapaColor(color);
        }

        //-by sport:
        public async Task<IEnumerable<Zapa>> GetZapaSport(string sport)
        {
            return await _zapazRepo.GetZapaSport(sport);
        }

        //-by brand:
        public async Task<IEnumerable<Zapa>> GetZapaBrand(string brand)
        {
            return await _zapazRepo.GetZapaBrand(brand);
        }

        //-by model:
        public async Task<IEnumerable<Zapa>> GetZapaModel(string model)
        {
            return await _zapazRepo.GetZapaModel(model);
        }

        //-by genre:
        public async Task<IEnumerable<Zapa>> GetZapaGenre(string genre)
        {
            return await _zapazRepo.GetZapaGenre(genre);
        }

        //-by custom filter:
        public async Task<IEnumerable<Zapa>> GetCustomZapa(string filter)
        {
            return await _zapazRepo.GetCustomZapa(filter);
        }

        //PUT 
        public async Task PutZapa(int id, Zapa zapa) => await _zapazRepo.PutZapa(id, zapa);

        //POST 
        public async Task<Zapa> PostZapa(Zapa zapa) => await _zapazRepo.PostZapa(zapa);

        //DELETE
        public async Task DeleteZapa(int id) => await _zapazRepo.DeleteZapa(id);
    }
}
