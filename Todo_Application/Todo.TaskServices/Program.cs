using Todo_TaskService.Adapters.DataProviders;
using Todo_TaskService.CoreLayer.CustomFilters;
using Todo.TaskService.Core.Ports;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//registering the depenedency injection
builder.Services.AddSingleton<ITaskService, InMemoryDataProvider>();
builder.Services.AddSingleton<TaskModelValidation>();

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
