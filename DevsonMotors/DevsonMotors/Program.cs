using DevsonMotors.Models;
using Microsoft.EntityFrameworkCore;
using DevsonMotors.Domains;
using Microsoft.Extensions.DependencyInjection;
using static DevsonMotors.Domains.CustomerService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<InventoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conString"));
});
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductsService, ProductService.ProductsService>();
builder.Services.AddScoped<ICustomersService, CustomerService.CustomersService>(); 
var app = builder.Build();
builder.Services.AddCors();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});

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
