using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class KodlamaioDevsDbContext:DbContext
    {
        public IConfiguration Configuration { get; set; }
        public KodlamaioDevsDbContext(DbContextOptions options,IConfiguration configuration) : base(options)
        {
            Configuration=configuration;
        }

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k=>k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Technologies);
            });

            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technologies").HasKey(k => k.Id);
                a.Property(p=>p.Id).HasColumnName("Id");
                a.Property(p=>p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(p=>p.Name).HasColumnName("Name");
                a.HasOne(p => p.ProgrammingLanguage);
            });
        }
    }
}
