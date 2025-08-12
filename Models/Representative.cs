// Faili: Models/Representative.cs
using System.ComponentModel.DataAnnotations;

public class Representative
{
    public virtual ICollection<Booking>? Bookings { get; set; }

    [Key]
    public int RepID { get; set; }
    public string? RepName { get; set; }
    public string? City { get; set; }
    public bool IsActive { get; set; }
}
