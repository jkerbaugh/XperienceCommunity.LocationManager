using Kentico.Xperience.Admin.Base.Forms;
using XperienceCommunity.Locator.FormComponents;
using XperienceCommunity.Locator.Models;

[assembly: RegisterFormComponent(
        BusinessHoursSelectorComponent.IDENTIFIER,
        typeof(BusinessHoursSelectorComponent),
        "Business Hours"
    )]

namespace XperienceCommunity.Locator.FormComponents;

public class BusinessHoursProperties : FormComponentProperties
{
    
}

public class BusinessHoursClientProperties : FormComponentClientProperties<BusinessHours>
{
    
}

public class BusinessHoursSelectorComponent : FormComponent<BusinessHoursProperties, BusinessHoursClientProperties, BusinessHours>
{
    public const string IDENTIFIER = "XperienceCommunity.BusinessHoursSelectorComponent";

    
    public override string ClientComponentName { get; } = $"{LocationManagerConstants.COMPONENT_NAME_PREFIX}/BusinessHoursSelector";
}