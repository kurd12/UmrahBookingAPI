// Faili: Models/Booking.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum BookingStatus { Pending, Approved, Rejected, Completed }

public class Booking
{
    [Key]
    public int BookingID { get; set; }

    // --- پەیوەندییەکان بەبێ [ForeignKey] ---
    [Required]
    public int UserID { get; set; }
    public User? User { get; set; }

    [Required]
    public int TripID { get; set; }
    public Trip? Trip { get; set; }

    public int? RepID { get; set; }
    public Representative? Representative { get; set; }

    public int? LeaderID { get; set; }
    public CampaignLeader? CampaignLeader { get; set; }

    // --- خانەکانی تر ---
    [Required]
    public BookingStatus BookingStatus { get; set; } = BookingStatus.Pending;
    public DateTime BookingDate { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }
}
