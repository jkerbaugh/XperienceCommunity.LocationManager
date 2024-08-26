using CMS.Membership;
using Kentico.Xperience.Admin.Base;
using Kentico.Xperience.Admin.Base.UIPages;
using XperienceCommunity.Locator;

[assembly: UIApplication(
    identifier: LocationManagerApplicationPage.IDENTIFIER,
    type: typeof(LocationManagerApplicationPage),
    slug: "locations",
    name: "Locations",
    category: BaseApplicationCategories.CONTENT_MANAGEMENT,
    icon: Icons.MapMarker,
    templateName: TemplateNames.SECTION_LAYOUT)]

namespace XperienceCommunity.Locator;

[UIPermission(SystemPermissions.VIEW)]
[UIPermission(SystemPermissions.CREATE)]
[UIPermission(SystemPermissions.UPDATE)]
[UIPermission(SystemPermissions.DELETE)]
public class LocationManagerApplicationPage : ApplicationPage
{
    public const string IDENTIFIER = "XperienceCommunity.Integrations.LocationManager.Admin";

}