using Microsoft.EntityFrameworkCore;
using PenApp.DataAccess.Data.Entities;

namespace PenApp.DataAccess.Data
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


