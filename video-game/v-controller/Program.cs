using Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Models;
using Persistence;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? connString = builder.Configuration.GetConnectionString("DefaultConnectionString");

//Add possible check to see if connstring is not null here
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connString));

//Add Interfaces
builder.Services.AddScoped<IRepository, GamesRepository>();

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
