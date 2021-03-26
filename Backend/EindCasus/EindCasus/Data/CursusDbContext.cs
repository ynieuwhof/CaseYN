using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Models;

namespace EindCasus.Data
{
    public class CursusDbContext : DbContext
    {
        public DbSet<Cursus> Cursussen { get; set; }
        public DbSet<CursusInstantie> CursusInstanties { get; set; }

        public CursusDbContext(DbContextOptions<CursusDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CursusDbContext;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cursus>().ToTable("Cursus");
            modelBuilder.Entity<CursusInstantie>().ToTable("CursusInstantie").HasIndex(p => new { p.StartDatum, p.CursusId }).IsUnique();
        }
    }
}
