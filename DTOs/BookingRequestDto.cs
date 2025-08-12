// Faili: DTOs/BookingRequestDto.cs
using System.ComponentModel.DataAnnotations;

public class BookingRequestDto
{
    [Required]
    public int UserID { get; set; }

    [Required]
    public int TripID { get; set; }

    // تەنها یەک property بۆ نوێنەر دەهێڵینەوە
    public int? RepID { get; set; } // ئارەزوومەندانەیە

    public string? Notes { get; set; }

    // ئەم خانانەی تر ئارەزوومەندانەن و دەتوانن بمێننەوە
    public int? LeaderID { get; set; }
    public string? FullName { get; set; }
    public string? Address { get; set; }
    public string? PersonalPhotoURL { get; set; }
    public string? PassportScanURL { get; set; }
}
