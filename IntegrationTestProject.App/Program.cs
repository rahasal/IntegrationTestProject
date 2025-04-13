using Microsoft.EntityFrameworkCore;
using RoomBookingApp.Core;
using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Persistence;
using RoomBookingApp.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RoomBookingAppDBContext>(options=>options.UseSqlite("DataSource=:memory:"));

builder.Services.AddScoped<IRoomBookingService, RoomBookingService>();
builder.Services.AddScoped<IRoomBookingRequestProcessor, RoomBookingRequestProcessor>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
