using AnimeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<AnimeShow> AnimeShows { get; set; }
        public DbSet<Cast> Casts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimeShow>()
                .HasOne(a => a.Category)
                .WithMany(c => c.AnimeShows)
                .HasForeignKey(a => a.CategoryId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cast>()
                .HasOne(c => c.AnimeShow)
                .WithMany(a => a.Casts)
                .HasForeignKey(c => c.AnimeShowId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
