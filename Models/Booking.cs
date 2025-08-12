// Faili: Models/Booking.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// پێناسەی Enum بۆ دۆخی حجز بە ئینگلیزی
public enum BookingStatus
{
    Pending,    // داواکراوە
    Approved,   // پەسەندکراوە
    Rejected,   // ڕەتکراوەتەوە
    Completed   // تەواوبووە
}

public class Booking
{
    [Key]
    public int BookingID { get; set; }

    [Required]
    public int UserID { get; set; }
    public User? User { get; set; }

    [Required]
    public int TripID { get; set; }
    public Trip? Trip { get; set; }

    [Required]
    public int RepID { get; set; }
    public Representative? Representative { get; set; }

    public int? LeaderID { get; set; }
    public CampaignLeader? CampaignLeader { get; set; }

    [Required]
    public BookingStatus BookingStatus { get; set; } = BookingStatus.Pending;

    public DateTime BookingDate { get; set; } = DateTime.UtcNow;
}
