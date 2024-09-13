using Microsoft.EntityFrameworkCore;
using WebApplicationOne.Model;

namespace WebApplicationOne.Data
{
    public class AppDbContext : DbContext
    {
        public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Role entity
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Manager"
                },
                new Role
                {
                    Id = 2,
                    Name = "Developer"
                }
            );

            // Seed data for Employee entity
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Code = "AVONTIX2065",
                    Location = "Miryalaguda",
                    Name = "Arjun",
                    RoleId = 1 // Reference the seeded Role with Id 1 (Manager)
                },
                new Employee
                {
                    Id = 2,  // Make sure Id is unique for each employee
                    Code = "AVONTIX2060",
                    Location = "MahaboobNagar",
                    Name = "Mahesh",
                    RoleId = 2 // Reference the seeded Role with Id 2 (Developer)
                }
                );
        }
    }
}
