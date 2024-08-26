using CMS.Membership;
using Kentico.Xperience.Admin.Base;
using XperienceCommunity.LocationManager;
using XperienceCommunity.Locator;

[assembly: UIPage(
        typeof(LocationManagerApplicationPage),
        "locations",
        typeof(LocationListingPage),
        name: "List of Locations",
        templateName: TemplateNames.LISTING,
        order: UIPageOrder.NoOrder
    )]

namespace XperienceCommunity.Locator;

[UIEvaluatePermission(SystemPermissions.VIEW)]
public class LocationListingPage : ListingPage
{
    protected override string ObjectType => LocationInfo.OBJECT_TYPE;
    
    public override async Task ConfigurePage()
    {
        PageConfiguration.ColumnConfigurations
            .AddColumn(nameof(LocationInfo.Name), "Name", defaultSortDirection: SortTypeEnum.Asc, sortable: true);

        // PageConfiguration.AddEditRowAction<IndexEditPage>();
        // PageConfiguration.TableActions.AddCommand("Rebuild", nameof(Rebuild), icon: Icons.RotateRight);
        // PageConfiguration.TableActions.AddDeleteAction(nameof(Delete), "Delete");
        
        PageConfiguration.HeaderActions.AddLink<LocationCreatePage>("Create");

        await base.ConfigurePage();
    }
}