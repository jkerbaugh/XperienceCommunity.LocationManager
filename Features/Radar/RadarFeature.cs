using Kentico.Xperience.Admin.Base.Forms;
using Microsoft.Extensions.Options;
using XperienceCommunity.Locator.FormComponents;
using XperienceCommunity.Locator.Interfaces;

namespace XperienceCommunity.Locator;

public class RadarFeature(IOptions<RadarOptions> options) : ILocatorFeature
{
    public string Name => "Radar";
    
    public void ConfigureClientProperties(AddressSelectorClientProperties clientProperties)
    {
        clientProperties.ApiKey = options.Value.PublicKey;
    }

    public void ToFormComponentClientProperties(AddressSelectorProperties properties)
    {
        throw new NotImplementedException();
    }
}