using BankSimulation.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Dapper Context Konfigürasyonu
// Manuel SQL sorguları ve veri erişimi için kullanılır.
builder.Services.AddSingleton<DapperContext>();

// API ve Swagger Servisleri
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() 
    { 
        Title = "Bank Simulation API", 
        Version = "v1",
        Description = "38 Tablolu Banka Simülasyonu - Dapper ile Saf SQL"
    });
});
builder.Services.AddControllers();

var app = builder.Build();

// HTTP Request Pipeline Konfigürasyonu
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();