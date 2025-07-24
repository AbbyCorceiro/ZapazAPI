using Microsoft.EntityFrameworkCore;
using ZapazAPI.Models;

namespace ZapazAPI.Context
{
    public class ZapaDBContext : DbContext
    {
        public ZapaDBContext(DbContextOptions<ZapaDBContext>options):base(options) { }
        public DbSet<Zapa> Zapas { get; set; }
    }
}
