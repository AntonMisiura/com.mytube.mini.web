using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace com.mytube.mini.web.Models
{
    public class TubeContext : DbContext
    {
        private IConfigurationRoot _config;

        public TubeContext(IConfigurationRoot config, DbContextOptions options)
            : base(options)
        {
            _config = config;
        }

        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Videos> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:TubeContextConnection"]);
        }
    }
}
