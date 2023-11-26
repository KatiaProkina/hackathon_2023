using Microsoft.EntityFrameworkCore;
using ShootScares.API.Data;
using ShootScares.API.Domain;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ReactPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<GameDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration
            .GetConnectionString("GameDb"));
    });

    builder.Services.AddScoped<PlayersRepository>();
    builder.Services.AddScoped<GameResultsRepository>();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("ReactPolicy", builder =>
        {
            builder.WithOrigins("https://hackathon-2023-p9o3.vercel.app")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
    });
}