using ECommerceServer.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ECommerceServer.Application.Repositories.CustomerRepositories;
using ECommerceServer.Persistance.Repositories.CustomerRepositories;
using ECommerceServer.Application.Repositories.OrderRepositories;
using ECommerceServer.Persistance.Repositories.OrderRepositories;
using ECommerceServer.Application.Repositories.ProductRepositories;
using ECommerceServer.Persistance.Repositories.ProductRepositories;
using ECommerceServer.Application.Repositories.Repositories;

namespace ECommerceServer.Persistance.Extensions;

public static class ServiceRegistration
{
    public static void AddPersistanceServices(this IServiceCollection services)
    {
        ConfigurationManager configurationManager = new();
        configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerceServer.API"));
        configurationManager.AddJsonFile("appsettings.json");

        services.AddDbContext<ECommerceServerDbContext>(options =>
            options.UseNpgsql(configurationManager.GetConnectionString("PostgreSql"))
        );

        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
    }
}
