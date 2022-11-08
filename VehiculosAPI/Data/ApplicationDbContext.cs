

using VehiculosAPI.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using VehiculosAPI.Models;


namespace VehiculosAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }       

        public DbSet<Users> Users { get; set; }

        public DbSet<Times> Times { get; set; }
        public DbSet<Activities> Activities { get; set; }
    }  
    
}
