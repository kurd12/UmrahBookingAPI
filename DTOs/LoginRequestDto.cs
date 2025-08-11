// Faili: Models/DTOs/LoginRequestDto.cs
using System.ComponentModel.DataAnnotations;

public class LoginRequestDto
{
    [Required]
    public string? PhoneNumber { get; set; }
}
