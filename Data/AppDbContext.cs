using Microsoft.EntityFrameworkCore;
using NatuViva.Models;

namespace NatuViva.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    
        public DbSet<Suplemento> Suplementos { get; set; }


    }
}
