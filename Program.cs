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

app.MapPost("api/task", async ([FromServices] TaskContext dbContext, [FromBody] EF_Fundamentals.Models.Task task) =>
{
    task.TaskId = Guid.NewGuid();
    task.CreationDate = DateTime.Now;
    await dbContext.tasks.AddAsync(task);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
    
});

app.MapPut("api/task/{id}", async ([FromServices] TaskContext dbContext, [FromBody] EF_Fundamentals.Models.Task task, [FromRoute] Guid id) =>
{
    var currentTask = dbContext.tasks.Find(id);

    if(currentTask != null)
    {
        currentTask.CategoryId = task.CategoryId;
        currentTask.Title = task.Title;
        currentTask.PriorityTask = task.PriorityTask;
        currentTask.Description = task.Description;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }   
        
    return Results.NotFound();
    
});

app.MapDelete("api/task/{id}", async ([FromServices] TaskContext dbContext, [FromRoute] Guid id ) =>
{
    var currentTask = dbContext.tasks.Find(id);

    if(currentTask != null)
    {
        dbContext.Remove(currentTask);
        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }  

    return Results.NotFound();
     
});

app.Run();
