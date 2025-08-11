// Faili: Middleware/ApiKeyMiddleware.cs
public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private const string ApiKeyHeaderName = "X-API-Key"; // ناوی ئەو Headerـەی کلیلی تێدا دەنێردرێت

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
    {
        // تەنها ئەو داواکاریانە بپشکنە کە بۆ بەشی ئەدمین دێن
        if (context.Request.Path.StartsWithSegments("/api/Admin"))
        {
            // وەرگرتنی کلیلی نهێنی لە فایلی appsettings.json
            var apiKey = configuration.GetValue<string>("AdminApiKey");

            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey) || apiKey != extractedApiKey)
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Invalid or missing API Key.");
                return;
            }
        }

        await _next(context);
    }
}
