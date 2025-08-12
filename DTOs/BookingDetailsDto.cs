// Faili: Models/DTOs/BookingDetailsDto.cs
using System;
using System.Collections.Generic;

public class BookingDetailsDto
{
    public int BookingID { get; set; }
    public string? TripType { get; set; } // گرنگ: دەبێت string بێت
    public decimal TripPrice { get; set; }
    public string? RepresentativeName { get; set; }
    public string? CampaignLeaderName { get; set; }
    public string? BookingStatus { get; set; } // گرنگ: دەبێت string بێت
    public DateTime BookingDate { get; set; }
    public decimal TotalPaid { get; set; }
    public decimal AmountDue { get; set; }
    public List<Payment>? Payments { get; set; }
}
