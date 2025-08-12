using Microsoft.EntityFrameworkCore;
using UmrahBookingAPI; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// **کۆدی نوێ و زیرەک بۆ دروستکردنی Connection String**
// ئەگەر لەسەر سێرڤەری Railway بووین، خۆی Connection String دروست دەکات
if (builder.Environment.IsProduction())
{
    var dbHost = builder.Configuration["MYSQLHOST"];
    var dbPort = builder.Configuration["MYSQLPORT"];
    var dbUser = builder.Configuration["MYSQLUSER"];
    var dbPass = builder.Configuration["MYSQLPASSWORD"];
    var dbName = builder.Configuration["MYSQLDATABASE"];

    connectionString = $"Server={dbHost};Port={dbPort};Database={dbName};User={dbUser};Password={dbPass};";
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment()) // ئەم بەشەمان لابرد بۆ ئەوەی Swagger هەمیشە کار بکات
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
