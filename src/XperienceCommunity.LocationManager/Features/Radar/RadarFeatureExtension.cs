using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace XperienceCommunity.Locator;

public static class RadarFeatureExtension
{
    public static ILocationsFeatureBuilder UseRadar(this ILocationsFeatureBuilder builder)
    {
        builder.Use<RadarOptions>();
        return builder.UseRadarInternal();
    }
    
    public static ILocationsFeatureBuilder UseRadar(this ILocationsFeatureBuilder builder,
        Action<RadarOptions>? options)
    {
        builder.Use(options);
        return builder.UseRadarInternal();
    }

    private static ILocationsFeatureBuilder UseRadarInternal(this ILocationsFeatureBuilder builder)
    {
        var services = builder.Services;

        builder.UseFeature<RadarFeature>();
        
        return builder;
    }
}