// Faili: Controllers/TripsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TripsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Trips
    // ئەم Endpointـە هەموو گەشتە بەردەستەکان دەگەڕێنێتەوە
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Trip>>> GetAvailableTrips()
    {
        return await _context.Trips.Where(t => t.IsAvailable == true).ToListAsync();
    }

    // GET: api/Trips/5
    // ئەم Endpointـە تەنها یەک گەشت بەپێی ID دەگەڕێنێتەوە
    [HttpGet("{id}")]
    public async Task<ActionResult<Trip>> GetTrip(int id)
    {
        var trip = await _context.Trips.FindAsync(id);

        if (trip == null)
        {
            return NotFound(); // ئەگەر گەشتەکە نەدۆزرایەوە، هەڵەی 404 دەگەڕێنێتەوە
        }

        return trip;
    }
}
