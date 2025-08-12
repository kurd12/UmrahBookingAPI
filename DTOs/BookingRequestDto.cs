// Faili: DTOs/BookingRequestDto.cs
using System.ComponentModel.DataAnnotations;

public class BookingRequestDto
{
    [Required] // UserID هەمیشە پێویستە
    public int UserID { get; set; }

    [Required] // TripID هەمیشە پێویستە
    public int TripID { get; set; }

    // ================== گۆڕانکارییەکان لێرەدایە ==================

    // RepID ئارەزوومەندانەیە
    public int? RepID { get; set; } // <-- ؟ زیادکرا و [Required] لابرا

    // ئەم زانیاریانە لەوانەیە دواتر زیاد بکرێن، بۆیە پێویست نین لە کاتی دروستکردندا
    public string? FullName { get; set; }  // <-- [Required] لابرا
    public string? Address { get; set; }   // <-- [Required] لابرا

    public int? LeaderID { get; set; }
    public string? PersonalPhotoURL { get; set; }
    public string? PassportScanURL { get; set; }

    // Notes زیاد دەکەین چونکە لە MAUIـیەوە دەینێرین
    public string? Notes { get; set; }
    // ==========================================================
}
