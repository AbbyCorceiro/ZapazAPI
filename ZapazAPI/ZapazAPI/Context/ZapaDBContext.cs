using Microsoft.EntityFrameworkCore;
using ZapazAPI.Entities;
using ZapazAPI.Models;

namespace ZapazAPI.Context
{
    public class ZapaDBContext : DbContext
    {
        public ZapaDBContext(DbContextOptions<ZapaDBContext>options):base(options) { }
        public DbSet<Zapa> Zapas { get; set; }
        public DbSet<User> Users { get; set; } 
    }
}
