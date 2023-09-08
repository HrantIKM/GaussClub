using GaussClub.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Label = GaussClub.Models.Label;

namespace GaussClub.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<University> Universities { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<ArticleLabel> ArticleLabels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Article>()
                .HasIndex(u => u.Slug)
                .IsUnique();

            builder.Entity<ArticleLabel>()
                .HasKey(al => new { al.ArticleId, al.LabelId });

            builder.Entity<ArticleLabel>()
                .HasOne(al => al.Article)
                .WithMany(a => a.ArticleLabels)
                .HasForeignKey(al => al.ArticleId);

            builder.Entity<ArticleLabel>()
                .HasOne(al => al.Label)
                .WithMany(l => l.ArticleLabels)
                .HasForeignKey(al => al.LabelId);

        }

    }
}
