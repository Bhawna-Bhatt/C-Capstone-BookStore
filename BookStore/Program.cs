using BookStore.DbContexts;
using BookStore.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/bookstore.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

//Serilog Logger
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<BookStoreContext>(dbContextOptions
    => dbContextOptions.UseSqlServer(builder.Configuration["ConnectionStrings:BookStoreDbConnectionString"]));


builder.Services.AddScoped<IBookstoreRepository, BookStoreRepository>();

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
