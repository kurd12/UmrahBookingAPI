// Faili: Controllers/RepresentativesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class RepresentativesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RepresentativesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Representatives
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Representative>>> GetRepresentatives()
    {
        return await _context.Representatives.ToListAsync();
    }
}
