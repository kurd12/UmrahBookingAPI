// Faili: Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    // ئەمە بۆ هەڵگرتنی کاتیی کۆدەکانە، لە پرۆژەی ڕاستەقینەدا دەبێت لە شوێنێکی باشتر هەڵبگیرێت
    private static readonly Dictionary<string, string> OtpStore = new Dictionary<string, string>();

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }

    // POST: api/Auth/Login
    [HttpPost("Login")]
    public IActionResult RequestOtp([FromBody] LoginRequestDto loginRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // دروستکردنی کۆدێکی کاتی (بۆ نموونە 6 ژمارە)
        var otp = new Random().Next(100000, 999999).ToString();

        // هەڵگرتنی کاتیی کۆدەکە
        OtpStore[loginRequest.PhoneNumber] = otp;

        // لە پرۆژەی ڕاستەقینەدا، لێرەدا کۆدەکە بە SMS دەنێردرێت
        // بۆ مەبەستی تاقیکردنەوە، کۆدەکە لە وەڵامدا دەگەڕێنینەوە
        return Ok(new { Message = "OTP sent successfully.", Otp = otp });
    }

    // POST: api/Auth/Verify
    [HttpPost("Verify")]
    public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto verifyRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // پشکنینی ئەوەی ئایا کۆدەکە دروستە یان نا
        if (!OtpStore.ContainsKey(verifyRequest.PhoneNumber) || OtpStore[verifyRequest.PhoneNumber] != verifyRequest.Otp)
        {
            return BadRequest(new { Message = "Invalid or expired OTP." });
        }

        // سڕینەوەی کۆدەکە دوای بەکارهێنان
        OtpStore.Remove(verifyRequest.PhoneNumber);

        // پشکنینی ئەوەی ئایا بەکارهێنەر پێشتر هەیە
        var user = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == verifyRequest.PhoneNumber);

        if (user == null)
        {
            // ئەگەر بەکارهێنەر نوێ بوو، دروستی دەکەین
            user = new User { PhoneNumber = verifyRequest.PhoneNumber };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        // لێرەدا دەتوانیت JWT Token دروست بکەیت و بیگەڕێنیتەوە
        // بۆ سادەیی، ئێستا تەنها زانیاری بەکارهێنەر دەگەڕێنینەوە
        return Ok(new { Message = "Login successful!", User = user });
    }
}
