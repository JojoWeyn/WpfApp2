using Microsoft.EntityFrameworkCore;

namespace WpfApp2.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding Positions
            modelBuilder.Entity<Position>().HasData(
                new Position { Id = 1, PositionName = "Manager" },
                new Position { Id = 2, PositionName = "Director" },
                new Position { Id = 3, PositionName = "Ispolnitel" }
            );

            // Seeding Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "User" }
            );

            // Seeding Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FullName = "Alice Johnson", Salary = 60000m, PositionId = 1 },
                new Employee { Id = 2, FullName = "Bob Smith", Salary = 50000m, PositionId = 2 },
                new Employee { Id = 3, FullName = "Charlie Brown", Salary = 45000m, PositionId = 3 }
            );

            // Seeding Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Login = "alice", Password = "password123", EmployeeId = 1, RoleId = 1 },
                new User { Id = 2, Login = "bob", Password = "password456", EmployeeId = 2, RoleId = 2 },
                new User { Id = 3, Login = "charlie", Password = "password789", EmployeeId = 3, RoleId = 2 }
            );
        }
    }
}
