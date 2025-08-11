// Faili: Models/Booking.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Booking
{
    public int? LeaderID { get; set; } // <-- زیادکراوە
    [Key]
    public int BookingID { get; set; }

    [Required]
    public int UserID { get; set; }

    [Required]
    public int TripID { get; set; }

    [Required]
    public int RepID { get; set; }

    public BookingStatus BookingStatus { get; set; } = BookingStatus.داواکراوە;

    public DateTime BookingDate { get; set; } = DateTime.UtcNow;

    [ForeignKey("LeaderID")]
    public CampaignLeader? CampaignLeader { get; set; } // <-- زیادکراوە

    // Navigation properties (بۆ ئاسانکاری لە وەرگرتنی داتای پەیوەندیدار)
    [ForeignKey("UserID")]
    public User? User { get; set; }

    [ForeignKey("TripID")]
    public Trip? Trip { get; set; }

    [ForeignKey("RepID")]
    public Representative? Representative { get; set; }
}

public enum BookingStatus
{
    داواکراوە,    // Requested
    پەسەندکراوە, // Approved
    ڕەتکراوەتەوە // Rejected
}
