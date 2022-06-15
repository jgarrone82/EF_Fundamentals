using EF_Fundamentals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TaskDb"));
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("taskConn"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", ([FromServices] TaskContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
});

app.MapGet("api/tasks", ([FromServices] TaskContext dbContext) =>
{
    return Results.Ok(dbContext.tasks);
});

app.MapGet("api/task/priority", ([FromServices] TaskContext dbContext, int id) =>
{
    return Results.Ok(dbContext.tasks.Include(p => p.Category).Where(a => (int)a.PriorityTask == id));
});

app.MapPost("api/task/priority", async ([FromServices] TaskContext dbContext, [FromBody] EF_Fundamentals.Models.Task task) =>
{
    task.TaskId = Guid.NewGuid();
    task.CreationDate = DateTime.Now;
    await dbContext.tasks.AddAsync(task);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
    
});

app.Run();
