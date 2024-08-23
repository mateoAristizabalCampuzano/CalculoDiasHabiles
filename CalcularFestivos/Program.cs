using CalcularFestivos.Bussiness.Holidays;
using CalcularFestivos.Repository;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
IConfiguration configuration = config.Build();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IHolidaysBussiness, HolidaysBussiness>();
builder.Services.AddTransient<IConnection, Connection>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
