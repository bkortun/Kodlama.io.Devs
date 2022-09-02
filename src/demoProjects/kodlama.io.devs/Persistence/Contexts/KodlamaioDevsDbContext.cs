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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }
    }
}
