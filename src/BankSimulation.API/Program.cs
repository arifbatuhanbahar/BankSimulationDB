using BankSimulation.Infrastructure.Data;
using BankSimulation.API.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ==================== SERVICES ====================

// Dapper Context (Veritabanı bağlantısı)
builder.Services.AddSingleton<DapperContext>();

// DataSeeder (Test verisi üretici)
builder.Services.AddScoped<DataSeeder>();

// Controllers
builder.Services.AddControllers();

// Swagger/OpenAPI Konfigürasyonu
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Bank Simulation API",
        Version = "v1.0",
        Description = "38 Tablolu Kapsamlı Banka Simülasyonu - VTYS Ders Projesi",
        Contact = new OpenApiContact
        {
            Name = "Batuhan",
            Email = "batuhan@example.com"
        }
    });

    // Endpoint'leri gruplandır
    options.TagActionsBy(api =>
    {
        if (api.GroupName != null) return new[] { api.GroupName };
        if (api.ActionDescriptor.RouteValues.TryGetValue("controller", out var controller))
            return new[] { controller };
        return new[] { "Other" };
    });

    options.OrderActionsBy(api => api.RelativePath);
});

// CORS (Frontend için)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// ==================== MIDDLEWARE ====================

// Development ortamında Swagger aktif
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Bank Simulation API v1");
        options.DocumentTitle = "Bank Simulation API";
        options.DefaultModelsExpandDepth(-1); // Model şemalarını gizle
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

// ==================== STARTUP LOG ====================

Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
Console.WriteLine("║           BANK SIMULATION API - VTYS DERS PROJESİ            ║");
Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
Console.WriteLine("║  📊 38 Tablo | 9 Modül | Dapper + Pure SQL                   ║");
Console.WriteLine("║  🌐 Swagger: http://localhost:5161/swagger                   ║");
Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
Console.WriteLine();

app.Run();
