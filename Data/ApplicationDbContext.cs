using Microsoft.EntityFrameworkCore;
using HdiBackend.Models;

namespace HdiBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TypeUser> Types { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Office> Offices { get; set; } = null!;
        public DbSet<Policy> Policies { get; set; } = null!;
        public DbSet<Report> Reports { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Policy>()
                .HasKey(p => new { p.IdOffice, p.PolicyNumber });

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Policy)
                .WithMany(p => p.Reports)
                .HasForeignKey(r => new { r.IdOffice, r.PolicyNumber })
                .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<TypeUser>().HasData(
                new TypeUser { IdType = 1, Type = "Admin" },
                new TypeUser { IdType = 2, Type = "Ajustador" }
            );
            
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    IdUser = 1,
                    Name= "admin",
                    Tel = "6632223344",
                    Username = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    IdType = 1
                },

                new User
                {
                    IdUser = 2,
                    Name = "Paco el Chato",
                    Username = "paco",
                    IdType = 2,
                    Password = BCrypt.Net.BCrypt.HashPassword("paco123")
                }
            );

            modelBuilder.Entity<Office>().HasData(
            new Office
            {
                IdOffice = 1,
                Address = "Oficina Central León"
            }
            );
            
        }
    }
}