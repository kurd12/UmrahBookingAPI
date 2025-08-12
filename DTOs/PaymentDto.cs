// Faili: Models/DTOs/PaymentDto.cs
using System;

public class PaymentDto
{
    public decimal AmountPaid { get; set; }
    public DateTime PaymentDate { get; set; }
    public string? PaymentMethod { get; set; }
}
