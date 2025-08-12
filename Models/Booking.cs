// Faili: Models/Booking.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum BookingStatus { Pending, Approved, Rejected, Completed }

public class Booking
{
    [Key]
    public int BookingID { get; set; }

    // --- پەیوەندی لەگەڵ User ---
    [Required]
    public int UserID { get; set; }
    [ForeignKey("UserID")] // <-- زیادکرا بۆ دڵنیایی
    public User? User { get; set; }

    // --- پەیوەندی لەگەڵ Trip ---
    [Required]
    public int TripID { get; set; }
    [ForeignKey("TripID")] // <-- زیادکرا بۆ دڵنیایی
    public Trip? Trip { get; set; }

    // --- پەیوەندی لەگەڵ Representative ---
    public int? RepID { get; set; } // ئارەزوومەندانە
    [ForeignKey("RepID")] // <-- زیادکرا بۆ دڵنیایی
    public Representative? Representative { get; set; }

    // --- پەیوەندی لەگەڵ CampaignLeader ---
    public int? LeaderID { get; set; } // ئارەزوومەندانە
    [ForeignKey("LeaderID")] // <-- زیادکرا بۆ دڵنیایی
    public CampaignLeader? CampaignLeader { get; set; }

    // --- خانەکانی تر ---
    [Required]
    public BookingStatus BookingStatus { get; set; } = BookingStatus.Pending;

    public DateTime BookingDate { get; set; } = DateTime.UtcNow;

    public string? Notes { get; set; }
}
