// Faili: Controllers/CampaignLeadersController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CampaignLeadersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CampaignLeadersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/CampaignLeaders
    // وەرگرتنی لیستی هەموو ڕێبەرە چالاکەکان
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CampaignLeader>>> GetActiveLeaders()
    {
        return await _context.CampaignLeaders.Where(l => l.IsActive == true).ToListAsync();
    }
}
