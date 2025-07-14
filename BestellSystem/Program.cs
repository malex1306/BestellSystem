using BestellSystem.Application.Repositories;
using BestellSystem.Application.Services;
using BestellSystem.Infrastructur.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBestellungRepository, InMemoryBestellungRepository>();
builder.Services.AddScoped<BestellService>();
builder.Services.AddScoped<PreisPruefService>();
builder.Services.AddScoped<RabattService>();

builder.Services.AddDbContext<BestellDbContext>(options =>
    options.UseSqlite("Data Source=bestellungen.deb"));

builder.Services.AddScoped<IBestellungRepository, EfCoreBestellungRepository>();

// Add services to the container.

builder.Services.AddControllers();
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
