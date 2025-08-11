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

    // کۆدی نوێ و باشترکراو
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Representative>>> GetRepresentatives()
    {
        try
        {
            // هەوڵدەدات لیستی نوێنەرەکان بهێنێت
            var representatives = await _context.Representatives.ToListAsync();
            return Ok(representatives); // ئەگەر سەرکەوتوو بوو، دەیانگەڕێنێتەوە
        }
        catch (Exception ex)
        {
            // ئەگەر هەر هەڵەیەک ڕوویدا، دەیگرێت
            Console.WriteLine("!!!!!!!!!! AN ERROR OCCURRED !!!!!!!!!!");
            Console.WriteLine(ex.ToString()); // هەموو وردەکارییەکانی هەڵەکە لە لۆگ چاپ دەکات

            // وەڵامێکی 500 دەگەڕێنێتەوە لەگەڵ پەیامی هەڵەکە
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

}
