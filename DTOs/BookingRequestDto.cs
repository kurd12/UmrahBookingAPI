// Faili: DTOs/BookingRequestDto.cs
using System.ComponentModel.DataAnnotations;

public class BookingRequestDto
{
    [Required]
    public int UserID { get; set; }

    [Required]
    public int TripID { get; set; }

    public int? RepID { get; set; } // ئارەزوومەندانە

    public string? Notes { get; set; }

    // ================== چارەسەرەکە لێرەدایە ==================
    // ئەم خانانە چیتر ناچاری نین لە کاتی دروستکردنی حجزدا
    public string? FullName { get; set; }  // <-- [Required] لابرا
    public string? Address { get; set; }   // <-- [Required] لابرا
    // =======================================================

    public int? LeaderID { get; set; }
    public string? PersonalPhotoURL { get; set; }
    public string? PassportScanURL { get; set; }
}
