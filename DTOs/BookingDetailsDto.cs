// Faili: Models/DTOs/BookingDetailsDto.cs
public class BookingDetailsDto
{
    public int BookingID { get; set; }
    public string? TripType { get; set; }
    public decimal TripPrice { get; set; }
    public string? RepresentativeName { get; set; }
    public string? CampaignLeaderName { get; set; }
    public string? BookingStatus { get; set; }
    public DateTime BookingDate { get; set; }
    public decimal TotalPaid { get; set; }
    public decimal AmountDue { get; set; }
    public List<PaymentDto>? Payments { get; set; }
}

public class PaymentDto
{
    public decimal AmountPaid { get; set; }
    public DateTime PaymentDate { get; set; }
    public string? PaymentMethod { get; set; }
}
