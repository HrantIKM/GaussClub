using GaussClub.Models;
using Microsoft.EntityFrameworkCore;

namespace GaussClub.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<University> Universities { get; set; }
        public DbSet<Article> Articles { get; set; }
/*        public DbSet<Label> Labels { get; set; }
*/
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Article>()
                .HasIndex(u => u.Slug)
                .IsUnique();
            
            /*builder.Entity<Label>()
                .HasIndex(u => u.Name)
                .IsUnique();*/
        }

    }
}
