using EF_Fundamentals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TaskDb"));
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("taskConn"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async ([FromServices] TaskContext dbContext ) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
});

app.Run();
