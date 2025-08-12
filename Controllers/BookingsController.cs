// Faili: Controllers/BookingsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BookingsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // POST: api/Bookings
    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] BookingRequestDto bookingDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = await _context.Users.FindAsync(bookingDto.UserID);
        if (user == null) return NotFound(new { Message = "User not found." });

        user.FullName = bookingDto.FullName;
        user.Address = bookingDto.Address;
        user.PersonalPhotoURL = bookingDto.PersonalPhotoURL;
        user.PassportScanURL = bookingDto.PassportScanURL;
        _context.Users.Update(user);

        var newBooking = new Booking
        {
            UserID = bookingDto.UserID,
            TripID = bookingDto.TripID,
            RepID = bookingDto.RepID,
            LeaderID = bookingDto.LeaderID,
            BookingStatus = BookingStatus.Pending 
        };

        _context.Bookings.Add(newBooking);
        await _context.SaveChangesAsync();

        return Ok(new { Message = "Booking created successfully!", BookingId = newBooking.BookingID });
    }

    // GET: api/Bookings/User/{userId}
    [HttpGet("User/{userId}")]
    public async Task<ActionResult<IEnumerable<BookingDetailsDto>>> GetUserBookings(int userId)
    {
        var bookings = await _context.Bookings
            .Include(b => b.Trip)
            .Include(b => b.Representative)
            .Include(b => b.CampaignLeader)
            .Where(b => b.UserID == userId)
            .Select(b => new BookingDetailsDto
            {
                BookingID = b.BookingID,
                TripType = b.Trip.TripType.ToString(),
                TripPrice = b.Trip.Price,
                RepresentativeName = b.Representative.RepName,
                CampaignLeaderName = b.CampaignLeader != null ? b.CampaignLeader.LeaderName : "دیاری نەکراوە",
                BookingStatus = b.BookingStatus.ToString(),
                BookingDate = b.BookingDate,
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

        if (!bookings.Any())
        {
            return NotFound("No bookings found for this user.");
        }

        return Ok(bookings);
    }

}
