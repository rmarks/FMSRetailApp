using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FMS.Retail.DAL;

public static class ConfigureServices
{
    public static IServiceCollection AddDALServices(this IServiceCollection services)
    {
        services.AddDbContext<FMSRetailContext>(options => options.UseInMemoryDatabase("FMSRetailDb"));

        return services;
    }
}
