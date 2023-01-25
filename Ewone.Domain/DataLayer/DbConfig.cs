namespace Ewone.Domain.DataLayer;

public static class DbConfig
{
    public static string ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? throw new Exception("error");
    // $"Host=postgres;Port=5432;Database=ewonedb;Username=postgres;Password=1;Tcp Keepalive=true;";
}