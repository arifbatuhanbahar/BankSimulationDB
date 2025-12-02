using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BankSimulation.Infrastructure.Data;

public class DapperContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
        // appsettings.json dosyasındaki "DefaultConnection" adresini alıyoruz
        _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
    }

    // Bu metod her çağrıldığında yeni bir veritabanı bağlantısı oluşturur
    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);
}