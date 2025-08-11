// Faili: Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<CampaignLeader> CampaignLeaders { get; set; } 
    public DbSet<Representative> Representatives { get; set; }
    public DbSet<Payment> Payments { get; set; } 
    public DbSet<User> Users { get; set; }
     public DbSet<Trip> Trips { get; set; }
     public DbSet<Booking> Bookings { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Trip>()
            .Property(t => t.TripType)
            .HasConversion<string>(); 
        modelBuilder.Entity<Booking>() 
            .Property(b => b.BookingStatus)
            .HasConversion<string>();
    }
}
