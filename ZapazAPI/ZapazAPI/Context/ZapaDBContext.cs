using Microsoft.EntityFrameworkCore;
using ZapazAPI.Models;

namespace ZapazAPI.Context
{
    public class ZapaDBContext : DbContext
    {
        public ZapaDBContext(DbContextOptions<ZapaDBContext>options):base(options) { }
        public DbSet<Zapa> Zapas { get; set; }
        public DbSet<UserDto> Users { get; set; } //Added DbSet for user entity
    }
}
