using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;
using WebApplication1.Models;
using static WebApplication1.Models.Skills;

namespace WebApplication1
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }


        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<DataContext>
        {
            public DataContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
                optionsBuilder.UseSqlServer("Server=.;Database=ResumeSahbadb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

                return new DataContext(optionsBuilder.Options);
            }
        }


        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Exprience> Expriences { get; set; }
        public DbSet<Hobbies> Hobby { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Personalinfo> Skills { get; set; }

        public DbSet<skills> Projects { get; set; }
        public DbSet<Skill> Skill { get; set; }



    }
}
