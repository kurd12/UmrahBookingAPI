// Faili: Models/Trip.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// پێناسەی Enum بۆ جۆری گەشت بە ئینگلیزی
public enum TripType
{
    Land, // گەشتی وشکانی
    Air   // گەشتی ئاسمانی
}

public class Trip
{
    public virtual ICollection<Booking>? Bookings { get; set; }

    [Key]
    public int TripID { get; set; }

    [Required]
    public TripType TripType { get; set; }

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public string? Description { get; set; }
    public string? HotelName { get; set; }
    public int? DistanceToKaaba { get; set; }
    public int? DistanceToProphetMosque { get; set; }
    public bool IsAvailable { get; set; } = true;
}
