using Microsoft.EntityFrameworkCore;
using PingPongWebApplication.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    //Table: Players
    public DbSet<Players> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Seed following records on create of database
        modelBuilder.Entity<Players>().HasData(new Players
        {
            Id = 1,
            FirstName = "Chandni",
            LastName = "Shah",
            Age = 23,
            SkillLevel = "Advanced",
            Email = "cshah9925@gmail.com"
        }, new Players
        {
            Id = 2,
            FirstName = "Harsh",
            LastName = "Shah",
            SkillLevel = "Beginner",
            Email = "jharsh23.hs@gmail.com"
        });
    }
}
