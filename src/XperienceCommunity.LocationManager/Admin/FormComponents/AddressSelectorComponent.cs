using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;
using XperienceCommunity.Locator.DataTypes;
using XperienceCommunity.Locator.FormComponents;
using XperienceCommunity.Locator.Interfaces;

[assembly: RegisterFormComponent(
    AddressSelectorComponent.IDENTIFIER,
    typeof(AddressSelectorComponent),
    "Address"
)]

namespace XperienceCommunity.Locator.FormComponents;

public class AddressSelectorComponentAttribute : FormComponentAttribute
{
}

public class AddressSelectorProperties : FormComponentProperties
{
}

public class AddressSelectorClientProperties : FormComponentClientProperties<Geolocation>
{
    public string? ApiKey { get; set; }
}

[ComponentAttribute(typeof(AddressSelectorComponentAttribute))]
public class AddressSelectorComponent(ILocatorFeature feature)
    : FormComponent<AddressSelectorProperties, AddressSelectorClientProperties, Geolocation>
{
    public const string IDENTIFIER = "XperienceCommunity.AddressSelectorComponent";

    public override string ClientComponentName =>
        $"{LocationManagerConstants.COMPONENT_NAME_PREFIX}/{feature.AddressComponentName}";


    protected override async Task ConfigureClientProperties(AddressSelectorClientProperties clientProperties)
    {
        await base.ConfigureClientProperties(clientProperties);

        feature.ConfigureClientProperties(clientProperties);
    }
}