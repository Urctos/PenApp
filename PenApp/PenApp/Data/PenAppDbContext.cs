using Microsoft.EntityFrameworkCore;
using PenApp.Entities;

namespace PenApp.Data
{
    public class PenAppDbContext : DbContext 
    {
        public DbSet<Employee> Employees => Set<Employee>();

        public DbSet<Manager> Managers => Set<Manager>();

        public DbSet<Pen> Pens => Set<Pen>();

        public DbSet<FountainPen> FountainPens => Set<FountainPen>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("PenAppDbContext");
        }
    }
}
