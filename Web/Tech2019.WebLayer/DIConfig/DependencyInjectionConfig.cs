using Microsoft.Extensions.DependencyInjection;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.BusinessLayer.ConcreteManagers;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.DataAccessLayer.EFConcreteDAL;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<TechDBContext>();

        services.AddScoped<IProductTraceDal, EFProductTraceDal>();

        services.AddScoped<IProductTraceService, ProductTraceManager>();

        return services;
    }
}