
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Payment.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Connection with the database
builder.Services.AddDbContext<PaymentContext>(
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("ConexaoMySQL"),
        new MySqlServerVersion("8.0")
    )
);

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
