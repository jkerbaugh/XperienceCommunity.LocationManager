using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using XperienceCommunity.Locator.Interfaces;

namespace XperienceCommunity.Locator;

public interface ILocationsFeatureBuilder
{
    internal IServiceCollection Services { get; }

    public ILocationsFeatureBuilder UseFeature<TFeature>() where TFeature : class, ILocatorFeature;
    
    internal ILocationsFeatureBuilder Use<TOptions>(Action<TOptions>? configure = null)
        where TOptions : class;
}

internal class LocationsFeatureBuilder(IServiceCollection services) : ILocationsFeatureBuilder
{
    public IServiceCollection Services => services;

    public ILocationsFeatureBuilder UseFeature<TFeature>() where TFeature : class, ILocatorFeature
    {
        var descriptor = new ServiceDescriptor(typeof(ILocatorFeature), typeof(TFeature), ServiceLifetime.Singleton);
        services.Replace(descriptor);
        return this;
    }


    public ILocationsFeatureBuilder Use<TOptions>(Action<TOptions>? configure = null) where TOptions 
        : class
    {
        var opts = services.AddOptions<TOptions>();
        if (configure is null)
            opts.BindConfiguration(typeof(TOptions).Name);
        else
            opts.Configure(configure);
        
        return this;
    }
    
}