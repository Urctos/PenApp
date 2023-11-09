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

        public DbSet<Car> Cars { get; set; }
        public DbSet<Pen> Pens { get; set; }
        public DbSet<FountainPen> FountainPens { get; set; }


    }

        //public DbSet<Employee> Employees => Set<Employee>();

        //public DbSet<Manager> Managers => Set<Manager>();

        //public DbSet<Pen> Pens => Set<Pen>();

        //public DbSet<FountainPen> FountainPens => Set<FountainPen>();

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseInMemoryDatabase("PenAppDbContext");
        //}
}


