// Faili: Models/DTOs/VerifyOtpDto.cs
using System.ComponentModel.DataAnnotations;

public class VerifyOtpDto
{
    [Required]
    public string? PhoneNumber { get; set; }

    [Required]
    public string? Otp { get; set; }
}
