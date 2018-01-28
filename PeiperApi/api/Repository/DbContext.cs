using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PeiperApi.Domain.Models;
using PeiperApi.Domain.Models.Deploy;

namespace api.Repository
{
    public class DbPsqlContext : DbContext
    {
        private readonly DbSettings _dbSettings;
        public DbSet<BuildData> SiteBuildData { get; set; }

        public DbPsqlContext(IOptions<DbSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_dbSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuildData>().ToTable("sitebuilds");
        }
    }
}
