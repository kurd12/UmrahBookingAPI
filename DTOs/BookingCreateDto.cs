// Faili: DTOs/BookingCreateDto.cs
using System.ComponentModel.DataAnnotations;

public class BookingCreateDto
{
    [Required]
    public int UserID { get; set; }

    [Required]
    public int TripID { get; set; }

    // ناوی ئەمە گرنگە، چونکە لە MAUIـیەوە بەم ناوە دێت
    public int? RepresentativeID { get; set; }

    public string? Notes { get; set; }
}
