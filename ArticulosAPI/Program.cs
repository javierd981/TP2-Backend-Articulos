using ArticulosAPI;
using ArticulosAPI.Data;
using Microsoft.EntityFrameworkCore;
using ArticulosAPI.Repositorios;
using ArticulosAPI.Repositorios.Contratos;
using ArticulosAPI.Servicios;
using ArticulosAPI.Servicios.Contratos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Inversión de dependencias
builder.Services.AddScoped<IArticuloRepositorio, ArticuloRepositorio>();
builder.Services.AddScoped<IArticuloServicio, ArticuloServicio>();

// Registrar AutoMapper escaneando el ensamblado actual
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingConfiguration>();
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
