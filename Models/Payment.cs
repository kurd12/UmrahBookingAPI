// Faili: Models/Payment.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Payment
{
    [Key]
    public int PaymentID { get; set; }

    [Required]
    public int BookingID { get; set; }
    public Booking? Booking { get; set; } // پەیوەندی لەگەڵ حجزی پەیوەندیدار

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal AmountPaid { get; set; }

    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

    [MaxLength(50)]
    public string? PaymentMethod { get; set; } // بۆ نموونە: "Cash", "Bank Transfer"

    public string? Notes { get; set; } // بۆ تێبینی
}
