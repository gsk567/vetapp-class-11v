﻿using Microsoft.Extensions.DependencyInjection;

namespace Service;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDogService, DogService>();
        
        return services;
    }
}