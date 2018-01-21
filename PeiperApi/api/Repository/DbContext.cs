using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class Test : CommonEntity
    {
        public string var1 { get; set; }
        public string var2 { get; set; }
    }

    public class CommonEntity
    {
        [Key]
        public int id { get; set; }
    }

    public class DbPsqlContext : DbContext
    {
        public DbSet<Test> TestData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Database=peiper;Username=pi;Password=niklas89");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().ToTable("test");
        }
    }
}
