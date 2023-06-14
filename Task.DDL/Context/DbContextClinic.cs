using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Entity;

namespace Task.DAL.Context
{
    public class DbContextClinic:DbContext
    {
        public DbContextClinic(DbContextOptions<DbContextClinic>options):base(options)
        {
                
        }
       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       //=> optionsBuilder.UseSqlServer("server=.;database=DbContextClinic;trusted_connection=true;");

        public DbSet<Secretary> Secretary { get; set; }
        public DbSet<Doctor> doctors { get; set; }

    }
}
