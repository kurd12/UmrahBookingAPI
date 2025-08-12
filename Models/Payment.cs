// Faili: Models/Payment.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table("Payments")]

public class Payment
{
    [Key]
    public int PaymentID { get; set; }

    [Required]
    public int BookingID { get; set; }

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal AmountPaid { get; set; }

    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public string? PaymentMethod { get; set; }
    public string? Notes { get; set; }

    [ForeignKey("BookingID")]
    public Booking? Booking { get; set; }
}
