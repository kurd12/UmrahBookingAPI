// Faili: Models/Representative.cs
using System.ComponentModel.DataAnnotations;

public class Representative
{
    [Key]
    public int RepresentativeID { get; set; }
    public string? RepName { get; set; }
    public string? City { get; set; }
    public bool IsActive { get; set; }
}
