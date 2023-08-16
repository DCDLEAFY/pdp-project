using Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Models;
using Persistence;
using Microsoft.Extensions.Options;
using Application;
using System.Reflection;
using Application.Mediatr.Request;

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

builder.Services.AddScoped<IGameService, GamesService>();

builder.Services.AddCors(config => {
    config.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

//Register Mediatr
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

var app = builder.Build();

app.UseCors();

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
