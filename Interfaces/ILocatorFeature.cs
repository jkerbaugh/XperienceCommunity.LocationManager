using Kentico.Xperience.Admin.Base.Forms;
using XperienceCommunity.Locator.FormComponents;

namespace XperienceCommunity.Locator.Interfaces;

public interface ILocatorFeature
{
    public string Name { get; }

    internal string AddressComponentName => $"{Name}AddressSelector";

    internal void ConfigureClientProperties(AddressSelectorClientProperties clientProperties);
    
    internal void ToFormComponentClientProperties(AddressSelectorProperties properties);
}