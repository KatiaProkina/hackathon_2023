using Microsoft.EntityFrameworkCore;
using ShootScares.API.Data;
using ShootScares.API.Domain;
using ShootScares.API.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GameDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("GameDb"));
});

builder.Services.AddScoped<PlayersRepository> ();
builder.Services.AddScoped<GameResultsRepository> ();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();