using System.Globalization;
using Newtonsoft.Json;

namespace XperienceCommunity.Locator.DataTypes;

public class Geolocation
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? FormattedAddress { get; set; }
    public string? AddressLabel { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? County { get; set; }
}