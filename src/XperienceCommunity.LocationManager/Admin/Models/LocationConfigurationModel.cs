using Kentico.Xperience.Admin.Base.FormAnnotations;
using XperienceCommunity.LocationManager;
using XperienceCommunity.Locator.DataTypes;
using XperienceCommunity.Locator.FormComponents;

namespace XperienceCommunity.Locator.Models;

public class LocationConfigurationModel
{
    [TextInputComponent(Label = "Name", Order = 0)]
    public string? Name { get; set; }
    
    [AddressSelectorComponent(Label = "Address", Order = 1)]
    [FormComponentConfiguration(typeof(AddressSelectorConfiguration))]
    public Geolocation? Address { get; set; }


    public void MapToLocationInfo(LocationInfo info)
    {
        info.Name = Name;
        info.Geolocation = Address;
    }
}