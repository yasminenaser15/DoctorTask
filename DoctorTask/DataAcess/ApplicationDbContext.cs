using DoctorTask.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorTask.DataAcess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointement> Appointements { get; set; }
        public DbSet<Specilization> specilizations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=doctorDatabase;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Specilization>().HasData(
            new Specilization { Id = 1, Name = "Cardiology", Description = "Heart specialist" },
            new Specilization { Id = 2, Name = "Dermatology", Description = "Skin specialist" },
            new Specilization { Id = 3, Name = "Neurology", Description = "Brain specialist" },
            new Specilization { Id = 4, Name = "Orthopedics", Description = "Bone specialist" },
            new Specilization { Id = 5, Name = "Pediatrics", Description = "Children specialist" },
            new Specilization { Id = 6, Name = "Ophthalmology", Description = "Eye specialist" },
            new Specilization { Id = 7, Name = "ENT", Description = "Ear Nose Throat" },
            new Specilization { Id = 8, Name = "Dentistry", Description = "Teeth specialist" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Dr. Ahmed", Phone = "0100000001", Email = "ahmed@test.com", ImageUrl = "team-1.jpg", SpecilizationId = 1 },
                new Doctor { Id = 2, Name = "Dr. Sara", Phone = "0100000002", Email = "sara@test.com", ImageUrl = "team-2.jpg", SpecilizationId = 2 },
                new Doctor { Id = 3, Name = "Dr. Ali", Phone = "0100000003", Email = "ali@test.com", ImageUrl = "team-3.jpg", SpecilizationId = 3 },
                new Doctor { Id = 4, Name = "Dr. Omar", Phone = "0100000004", Email = "omar@test.com", ImageUrl = "team-4.jpg", SpecilizationId = 4 },
                new Doctor { Id = 5, Name = "Dr. Nada", Phone = "0100000005", Email = "nada@test.com", ImageUrl = "team5.jpg", SpecilizationId = 5 },
                new Doctor { Id = 6, Name = "Dr. Hassan", Phone = "0100000006", Email = "hassan@test.com", ImageUrl = "team6.jpg", SpecilizationId = 6 },
                new Doctor { Id = 7, Name = "Dr. Laila", Phone = "0100000007", Email = "laila@test.com", ImageUrl = "team7.jpg", SpecilizationId = 7 },
                new Doctor { Id = 8, Name = "Dr. Karim", Phone = "0100000008", Email = "karim@test.com", ImageUrl = "team8.jpg", SpecilizationId = 8 }
            );
        }
    }
}
