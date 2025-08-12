// Faili: Models/Booking.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum BookingStatus { Pending, Approved, Rejected, Completed }

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

        public int? RepID { get; set; }
        public Representative? Representative { get; set; }

        // ================== چارەسەرەکە لێرەدایە ==================
        // بە EF Core دەڵێین کە ئەم propertyـیە پەیوەستە بە ستوونی LeaderID
        [ForeignKey("CampaignLeader")]
        public int? LeaderID { get; set; }
        public CampaignLeader? CampaignLeader { get; set; }
        // =======================================================

        [Required]
        public BookingStatus BookingStatus { get; set; } = BookingStatus.Pending;

        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        public string? Notes { get; set; }
    }
