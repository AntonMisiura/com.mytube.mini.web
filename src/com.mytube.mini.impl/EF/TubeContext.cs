using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using com.mytube.mini.core.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace com.mytube.mini.impl.EF
{
    public class TubeContext : DbContext
    {
        private IConfigurationRoot _config;

        public TubeContext(IConfigurationRoot config, DbContextOptions options)
            : base(options)
        {
            _config = config;
            //Database.SetInitializer<TubeContext>(null);
        }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:TubeContextConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Video>().ToTable("Video");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Rating>().ToTable("Rating");
            modelBuilder.Entity<Rating>().Property(p => p.Mark).HasColumnName("Rating");
        }
    }
}
