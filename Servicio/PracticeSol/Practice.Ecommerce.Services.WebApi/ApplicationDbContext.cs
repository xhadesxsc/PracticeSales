using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Practice.Ecommerce.Domain.Entity;
using System;

namespace Practice.Ecommerce.Services.WebApi
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<PeliculasActores>()
            //    .HasKey(x => new { x.ActorId, x.PeliculaId });

            //modelBuilder.Entity<PeliculasGeneros>()
            //    .HasKey(x => new { x.PeliculaId, x.GeneroId });

            //modelBuilder.Entity<PeliculasCines>()
            //    .HasKey(x => new { x.PeliculaId, x.CineId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Sales> Sales { get; set; }
    }
}