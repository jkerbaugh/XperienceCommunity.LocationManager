using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace XperienceCommunity.Locator;

public static class LocationManagerServiceCollectionExtensions
{
    public static IServiceCollection AddXperienceLocationManager(this IServiceCollection services,
        Action<ILocationsFeatureBuilder> configure)
    {
        var featureBuilder = new LocationsFeatureBuilder(services);
        configure(featureBuilder);
        
        services.AddSingleton<ILocationsFeatureBuilder>(featureBuilder);
        
        return services
            .AddXperienceLocationManagerInternal();
    }
    
    private static IServiceCollection AddXperienceLocationManagerInternal(this IServiceCollection services)
    {
        services
            .AddSingleton<ILocationManagerModuleInstaller, LocationManagerModuleInstaller>();

        services.Scan(x => x.FromAssemblyOf<LocationManagerModule>()
            .AddClasses(classes => classes.AssignableTo(typeof(IValidateOptions<>))
                .Where(t => !t.IsGenericType))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        return services;
    }
}