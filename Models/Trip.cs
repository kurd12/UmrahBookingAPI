// Faili: Models/Trip.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table("Trips")]

public class Trip
{
    [Key]
    public int TripID { get; set; }

    // Enum 'وشکانی' و 'ئاسمانی' لە بنکەی دراوە بە ژمارە 0 و 1 هەڵدەگیرێن
    public TripType TripType { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public string? Description { get; set; }

    public string? HotelName { get; set; }

    public int? DistanceToKaaba { get; set; }

    public int? DistanceToProphetMosque { get; set; }

    public bool IsAvailable { get; set; }
}

// پێناسەکردنی Enum بۆ جۆری گەشت
public enum TripType
{
    وشکانی, // 0
    ئاسمانی  // 1
}
