// Faili: Data/ApplicationDbContext.cs

// usingـە پێویستەکان
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;

// پێناسەی DbContext
public class ApplicationDbContext : DbContext
{
    // Constructor
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // پێناسەی خشتەکان (Tables)
    public DbSet<User> Users { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Representative> Representatives { get; set; }
    public DbSet<CampaignLeader> CampaignLeaders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<TripItinerary> TripItineraries { get; set; }

    // پێناسەکردنی مۆدێل و پەیوەندییەکان
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ================== چارەسەری ١: پێناسەکردنی پەیوەندییەکان ==================
        // ئەمە کێشەی Build چارەسەر دەکات
        modelBuilder.Entity<Booking>(entity =>
        {
            // پەیوەندی لەگەڵ User
            entity.HasOne(b => b.User)
                  .WithMany() // EF Core خۆی پەیوەندییەکە تێدەگات
                  .HasForeignKey(b => b.UserID)
                  .IsRequired();

            // پەیوەندی لەگەڵ Trip
            entity.HasOne(b => b.Trip)
                  .WithMany()
                  .HasForeignKey(b => b.TripID)
                  .IsRequired();

            // پەیوەندی لەگەڵ Representative
            entity.HasOne(b => b.Representative)
                  .WithMany()
                  .HasForeignKey(b => b.RepID)
                  .IsRequired(false); // ئارەزوومەندانە

            // پەیوەندی لەگەڵ CampaignLeader
            entity.HasOne(b => b.CampaignLeader)
                  .WithMany()
                  .HasForeignKey(b => b.LeaderID)
                  .IsRequired(false); // ئارەزوومەندانە
        });

        // ================== چارەسەری ٢: چارەسەری کێشەی Enum ==================
        // ئەمە کێشەی 'Can't convert Enum to Int32' چارەسەر دەکات
        // ئەم کۆدە بە شێوەیەکی ئۆتۆماتیکی هەموو Enumـەکان دەکات بە string
        if (Database.ProviderName == "Pomelo.EntityFrameworkCore.MySql")
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType.IsEnum)
                    {
                        var enumType = property.ClrType;
                        var converterType = typeof(EnumToStringConverter<>).MakeGenericType(enumType);
                        var converter = (ValueConverter)Activator.CreateInstance(converterType, null);
                        property.SetValueConverter(converter);
                    }
                }
            }
        }
    }
}
