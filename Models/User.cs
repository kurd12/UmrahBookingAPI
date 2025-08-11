// Faili: Models/User.cs
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int UserID { get; set; }

    [Required]
    public string? PhoneNumber { get; set; }

    public string? FullName { get; set; }
    public string? Address { get; set; }
    public string? PersonalPhotoURL { get; set; }
    public string? PassportScanURL { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
