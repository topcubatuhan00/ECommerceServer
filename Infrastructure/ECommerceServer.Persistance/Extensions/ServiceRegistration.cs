using ECommerceServer.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ECommerceServer.Persistance.Extensions;

public static class ServiceRegistration
{
    public static void AddPersistanceServices(this IServiceCollection services)
    {
        ConfigurationManager configurationManager = new();
        configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerceServer.API")););
        configurationManager.AddJsonFile("appsettings.json");

        services.AddDbContext<ECommerceServerDbContext>(options =>
            options.UseNpgsql(configurationManager.GetConnectionString("PostgreSql"))
        );
    }
}
