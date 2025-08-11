// Faili: Controllers/BookingsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly ApplicationDbContext _context;


    // Faili: Controllers/BookingsController.cs

    // GET: api/Bookings/User/{userId}
    [HttpGet("User/{userId}")]
    public async Task<ActionResult<IEnumerable<BookingDetailsDto>>> GetUserBookings(int userId)
    {
        var bookings = await _context.Bookings
            .Include(b => b.Trip) // وەرگرتنی زانیاری گەشت
            .Include(b => b.Representative) // وەرگرتنی زانیاری نوێنەر
            .Include(b => b.CampaignLeader) // وەرگرتنی زانیاری ڕێبەر
            .Where(b => b.UserID == userId)
            .Select(b => new BookingDetailsDto
            {
                BookingID = b.BookingID,
                TripType = b.Trip.TripType.ToString(),
                TripPrice = b.Trip.Price,
                RepresentativeName = b.Representative.RepName,
                CampaignLeaderName = b.CampaignLeader != null ? b.CampaignLeader.LeaderName : "N/A",
                BookingStatus = b.BookingStatus.ToString(),
                BookingDate = b.BookingDate,
                // لێرەدا پارەدانەکان حیساب دەکەین
                TotalPaid = _context.Payments.Where(p => p.BookingID == b.BookingID).Sum(p => (decimal?)p.AmountPaid) ?? 0,
                AmountDue = b.Trip.Price - (_context.Payments.Where(p => p.BookingID == b.BookingID).Sum(p => (decimal?)p.AmountPaid) ?? 0),
                Payments = _context.Payments.Where(p => p.BookingID == b.BookingID).Select(p => new PaymentDto
                {
                    AmountPaid = p.AmountPaid,
                    PaymentDate = p.PaymentDate,
                    PaymentMethod = p.PaymentMethod
                }).ToList()
            })
            .ToListAsync();

        if (bookings == null || !bookings.Any())
        {
            return NotFound("No bookings found for this user.");
        }

        return Ok(bookings);
    }
    public BookingsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // POST: api/Bookings
    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] BookingRequestDto bookingDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // ١. پشکنینی ئەوەی ئایا بەکارهێنەر بوونی هەیە
        var user = await _context.Users.FindAsync(bookingDto.UserID);
        if (user == null)
        {
            return NotFound(new { Message = "User not found." });
        }

        // ٢. نوێکردنەوەی زانیارییەکانی بەکارهێنەر
        user.FullName = bookingDto.FullName;
        user.Address = bookingDto.Address;
        user.PersonalPhotoURL = bookingDto.PersonalPhotoURL;
        user.PassportScanURL = bookingDto.PassportScanURL;
        _context.Users.Update(user);

        // ٣. دروستکردنی حجزی نوێ
     
        var newBooking = new Booking
        {
            UserID = bookingDto.UserID,
            TripID = bookingDto.TripID,
            RepID = bookingDto.RepID,
            LeaderID = bookingDto.LeaderID 
        };
        // ...


        _context.Bookings.Add(newBooking);
        await _context.SaveChangesAsync();

        // ٤. گەڕاندنەوەی وەڵامی سەرکەوتوو
        return Ok(new { Message = "Booking created successfully!", BookingId = newBooking.BookingID });



    }
}
