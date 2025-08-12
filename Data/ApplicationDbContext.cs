// Faili: Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Representative> Representatives { get; set; }
    public DbSet<CampaignLeader> CampaignLeaders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<TripItinerary> TripItineraries { get; set; }

    // ================== چارەسەری یەکلاکەرەوە لێرەدایە ==================
    // Faili: Data/ApplicationDbContext.cs
    // ... (کۆدی تر)

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Booking>(entity =>
        {
            // ================== چارەسەری ڕاست لێرەدایە ==================
            // پەیوەندی لەگەڵ User
            entity.HasOne(b => b.User)
                  .WithMany(u => u.Bookings) // <-- گەڕایەوە بۆ WithMany
                  .HasForeignKey(b => b.UserID)
                  .IsRequired();

            // پەیوەندی لەگەڵ Trip
            entity.HasOne(b => b.Trip)
                  .WithMany(t => t.Bookings) // <-- گەڕایەوە بۆ WithMany
                  .HasForeignKey(b => b.TripID)
                  .IsRequired();

            // پەیوەندی لەگەڵ Representative
            entity.HasOne(b => b.Representative)
                  .WithMany(r => r.Bookings) // <-- گەڕایەوە بۆ WithMany
                  .HasForeignKey(b => b.RepID)
                  .IsRequired(false);

            // پەیوەندی لەگەڵ CampaignLeader
            entity.HasOne(b => b.CampaignLeader)
                  .WithMany(cl => cl.Bookings) // <-- گەڕایەوە بۆ WithMany
                  .HasForeignKey(b => b.LeaderID)
                  .IsRequired(false);
            // =======================================================
        });
    }
    // ... (کۆدی تر)
    // dotnet build

    // =================================================================
}
