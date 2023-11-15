using Microsoft.EntityFrameworkCore;
using PenApp.Data.Entities;

namespace PenApp.Data
{
    public class PenAppDbContext : DbContext 
    {
        public PenAppDbContext(DbContextOptions<PenAppDbContext> options)
            : base(options)
        {        
        }

        public DbSet<Pen> Pens { get; set; }
        public DbSet<FountainPen> FountainPens { get; set; }

    }
}


