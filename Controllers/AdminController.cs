// Faili: Controllers/AdminController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    // PATCH: api/Admin/Bookings/{bookingId}/Approve
    [HttpPatch("Bookings/{bookingId}/Approve")]
    public async Task<IActionResult> ApproveBooking(int bookingId)
    {
        var booking = await _context.Bookings.FindAsync(bookingId);
        if (booking == null) return NotFound();

        booking.BookingStatus = BookingStatus.پەسەندکراوە;
        await _context.SaveChangesAsync();
        return Ok(new { Message = "Booking approved." });
    }

    // PATCH: api/Admin/Bookings/{bookingId}/Reject
    [HttpPatch("Bookings/{bookingId}/Reject")]
    public async Task<IActionResult> RejectBooking(int bookingId)
    {
        var booking = await _context.Bookings.FindAsync(bookingId);
        if (booking == null) return NotFound();

        booking.BookingStatus = BookingStatus.ڕەتکراوەتەوە;
        await _context.SaveChangesAsync();
        return Ok(new { Message = "Booking rejected." });
    }

    // POST: api/Admin/Payments
    [HttpPost("Payments")]
    public async Task<IActionResult> AddPayment([FromBody] Payment payment)
    {
        if (!ModelState.IsValid) return BadRequest();

        var bookingExists = await _context.Bookings.AnyAsync(b => b.BookingID == payment.BookingID);
        if (!bookingExists) return NotFound("Booking not found.");

        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
        return Ok(new { Message = "Payment added successfully.", PaymentId = payment.PaymentID });
    }
}
