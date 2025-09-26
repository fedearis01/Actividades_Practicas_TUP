using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ModeloParcial.Models;
using ModeloParcial.Repositories;
using ModeloParcial.Services;
 

var builder = WebApplication.CreateBuilder(args);

// =============================
// 1. Servicios
// =============================

// DbContext con SQL Server
builder.Services.AddDbContext<EnvioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios y servicios
builder.Services.AddScoped<IEnvioRepository, EnvioRepository>();
builder.Services.AddScoped<IEnvioService, EnvioService>();

// Controladores + manejo de ciclos en JSON
builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Envio API",
        Version = "v1",
        Description = "API REST para gestión de envíos"
    });
});

var app = builder.Build();

// =============================
// 2. Middleware
// =============================
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // útil para ver errores detallados
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Envio API v1");
        c.RoutePrefix = string.Empty; // Swagger en la raíz (https://localhost:xxxx/)
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
