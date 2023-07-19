using Carter;
using LogHub.Application;
using LogHub.Persistence;
using LogHub.Web.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCarter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseRateLimiter();

app.UseAuthorization();

app.MapControllers();

app.Run();
