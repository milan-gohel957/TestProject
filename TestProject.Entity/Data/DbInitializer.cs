using Microsoft.EntityFrameworkCore;
using TestProject.Entity.Models;

namespace TestProject.Entity.Data;

public class DbInitializer
{
    private readonly ModelBuilder modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        modelBuilder.Entity<User>(entity => 
        {
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
        });
        modelBuilder.Entity<User>().HasData(
               new User() { Id = 1, Email = "user1@email.com", Password = "123456", RoleId = 2 ,CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
               new User() { Id = 2, Email = "user2@email.com", Password = "123456", RoleId = 2 ,CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
               new User() { Id = 3, Email = "user3@email.com", Password = "123456", RoleId = 2 ,CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
               new User() { Id = 4, Email = "user4@email.com", Password = "123456", RoleId = 2 ,CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
               new User() { Id = 5, Email = "user5@email.com", Password = "123456", RoleId = 2 ,CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
               new User() { Id = 6, Email = "user6@email.com", Password = "123456", RoleId = 2 ,CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
               new User() { Id = 7, Email = "user7@email.com", Password = "123456", RoleId = 2 ,CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
               new User() { Id = 8, Email = "user8@email.com", Password = "123456", RoleId = 2 ,CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
               new User() { Id = 9, Email = "user9@email.com", Password = "123456", RoleId = 2 ,CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
               new User() { Id = 10, Email = "user10@email.com", Password = "123456", RoleId = 2 , CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
               new User() { Id = 11, Email = "user10@email.com", Password = "123456", RoleId = 2 , CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
               new User() { Id = 12, Email = "admin1@email.com", Password = "123456", RoleId = 1 , CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now}
        );
        modelBuilder.Entity<Role>().HasData(
            new Role(){Id = 1, RoleName = "Admin"},
            new Role(){Id = 2, RoleName = "User"}
        );
    }
}
