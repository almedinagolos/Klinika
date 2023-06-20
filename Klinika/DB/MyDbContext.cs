using Klinika.Database;
using Microsoft.EntityFrameworkCore;

namespace Klinika.DB
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Pacijent> Pacijent { get; set; }
        public DbSet<Ljekar> Ljekar { get; set; }
        public DbSet<Prijem> Prijem { get; set; }
        public DbSet<Nalaz> Nalaz { get; set; }
    }
}
