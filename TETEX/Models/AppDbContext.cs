using Microsoft.EntityFrameworkCore;
namespace TETEX.Models
{
    public class AppDbContext  : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Course> Course { get; set; }
        public DbSet<AspNetUser> AspNetUser { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }
        public DbSet<Lessons> Lessons { get; set; }
        public DbSet<Sections> Sections { get; set; }

    }

}
