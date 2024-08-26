using System.Globalization;
using Newtonsoft.Json;
using XperienceCommunity.Locator.DataTypes;

namespace XperienceCommunity.Locator.Converters;

internal static class LocatorJsonConverter
{
    
    public static object ConvertToDbRepresentation<TType>(TType? value, object defaultValue, CultureInfo _)
    {
        if (value == null)
        {
            return defaultValue;
        }

        try
        {
            return JsonConvert.SerializeObject(value);
        }
        catch (Exception e)
        {
            throw new InvalidOperationException("An error occurred when serializing the data type.", e);
        }
    }

    public static TType ConvertToSystemRepresentation<TType>(object? value, TType defaultValue, CultureInfo _)
    {
        if (value == null)
        {
            return defaultValue;
        }

        // We know the value is stored in the database as a JSON string
        var stringValue = value as string;
        if (string.IsNullOrEmpty(stringValue))
        {
            return defaultValue;
        }

        try
        {
            return JsonConvert.DeserializeObject<TType>(stringValue) ?? defaultValue;
        }
        catch (Exception e)
        {
            throw new InvalidOperationException("An error occurred when deserializing the data type.", e);
        }
    }
}