using ExampleService_WebApi.Adapters.DataProviders;
using ExampleService_WebApi.CoreLayer.CustomFilters;
using ExampleService_WebApi.PortLayer.InterfaceClass;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//registering the depenedency injection
builder.Services.AddSingleton<ITaskInterface, InMemoryDataProvider>();
builder.Services.AddSingleton<RequestFromBodyValidation>();

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
