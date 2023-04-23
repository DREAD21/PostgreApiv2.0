using Microsoft.EntityFrameworkCore;
using PostgreApi.DAL.Entities;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение

builder.Services.AddEntityFrameworkNpgsql()
        .AddDbContext<PesfczomContext>(options =>
        {
            options.UseNpgsql("Host=hattie.db.elephantsql.com;port=5432;Username=pesfczom;Password=cW3CyCToaz-EQG1GK0l6PezvlzH9aNaR;Database=pesfczom");
        });

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
