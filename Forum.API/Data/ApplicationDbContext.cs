using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options){
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<User>().HasData(
            new { Id = 1, Username = "admin", Email = "admin@admin.admin", Password = "admin"}
        );
    }
}