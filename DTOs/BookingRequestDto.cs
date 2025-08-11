// Faili: Models/DTOs/BookingRequestDto.cs
using System.ComponentModel.DataAnnotations;

public class BookingRequestDto
{
    public int? LeaderID { get; set; } // <-- زیادکراوە

    [Required]
    public int UserID { get; set; }

    [Required]
    public int TripID { get; set; }

    [Required]
    public int RepID { get; set; }

    // زانیارییەکانی بەکارهێنەر کە لە کاتی حجزکردندا نوێ دەکرێنەوە
    [Required]
    public string? FullName { get; set; }

    [Required]
    public string? Address { get; set; }

    // لە پرۆژەی ڕاستەقینەدا، ئەمە دەبێت IFormFile بێت بۆ بارکردنی فایل
    // بەڵام بۆ سادەیی، ئێستا وەک string دایدەنێین
    public string? PersonalPhotoURL { get; set; }
    public string? PassportScanURL { get; set; }
}
