using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data;

public static class DependencyInjection
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddDbContext<EntityContext>(options =>
        {
            options.UseInMemoryDatabase("inmemory");
        });
        
        return services;
    }
}