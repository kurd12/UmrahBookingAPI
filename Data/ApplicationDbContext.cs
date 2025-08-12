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

    // ================== چارەسەری یەکلاکەرەوە لێرەدایە ==================
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // پێناسەکردنی ڕوونی پەیوەندییەکانی خشتەی Bookings
        modelBuilder.Entity<Booking>(entity =>
        {
            // پەیوەندی لەگەڵ User
            entity.HasOne(b => b.User)
                  .WithMany() // وا دابنێ User چەندین Bookingـی هەیە
                  .HasForeignKey(b => b.UserID)
                  .IsRequired(); // UserID ناچارییە

            // پەیوەندی لەگەڵ Trip
            entity.HasOne(b => b.Trip)
                  .WithMany() // وا دابنێ Trip چەندین Bookingـی هەیە
                  .HasForeignKey(b => b.TripID)
                  .IsRequired(); // TripID ناچارییە

            // پەیوەندی لەگەڵ Representative
            entity.HasOne(b => b.Representative)
                  .WithMany() // وا دابنێ Representative چەندین Bookingـی هەیە
                  .HasForeignKey(b => b.RepID)
                  .IsRequired(false); // RepID ئارەزوومەندانەیە

            // پەیوەندی لەگەڵ CampaignLeader
            entity.HasOne(b => b.CampaignLeader)
                  .WithMany() // وا دابنێ CampaignLeader چەندین Bookingـی هەیە
                  .HasForeignKey(b => b.LeaderID)
                  .IsRequired(false); // LeaderID ئارەزوومەندانەیە
        });
    }
    // =================================================================
}
