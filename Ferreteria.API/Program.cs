using Ferreteria.Data.EF;
using Ferreteria.Data.Repositories.Interfaces;
using Ferreteria.Data.Repositories.Implementations;
using Ferreteria.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
builder.Services.AddDbContext<FerreteriaDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

 builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
 builder.Services.AddScoped<IProductoService, ProductoService>();
 builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
 builder.Services.AddScoped<IClienteService, ClienteService>();
 builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
 builder.Services.AddScoped<IProveedorService, ProveedorService>();
 builder.Services.AddScoped<IVentaRepository, VentaRepository>();
 builder.Services.AddScoped<IVentaService, VentaService>();

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
