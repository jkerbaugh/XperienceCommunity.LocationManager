using CMS.DataEngine;
using CMS.Helpers;
using Kentico.Forms.Web.Mvc;
using Kentico.Xperience.Admin.Base;
using Newtonsoft.Json;
using XperienceCommunity.Locator;
using XperienceCommunity.Locator.Converters;
using XperienceCommunity.Locator.DataTypes;
using XperienceCommunity.Locator.FormComponents;
using XperienceCommunity.Locator.Models;

[assembly: CMS.RegisterModule(typeof(LocationManagerAdminModule))]

namespace XperienceCommunity.Locator
{
    internal class LocationManagerAdminModule() : AdminModule("XperienceCommunity.LocationManager.Admin")
    {
        protected override void OnPreInit()
        {
            base.OnPreInit();
            
            DataTypeManager.RegisterDataTypes(
                new DataType<Geolocation>("nvarchar(max)", "geolocation", "xs:string",
                    LocatorJsonConverter.ConvertToSystemRepresentation,
                    LocatorJsonConverter.ConvertToDbRepresentation,
                    new DefaultDataTypeTextSerializer("text"))
                {
                    Hidden = false,
                    DefaultValue = new Geolocation(),
                    HasConfigurableDefaultValue = false,
                }
            );
            
            DataTypeManager.RegisterDataTypes(
                new DataType<BusinessHours>("nvarchar(max)", "businesshours", "xs:string",
                    LocatorJsonConverter.ConvertToSystemRepresentation,
                    LocatorJsonConverter.ConvertToDbRepresentation,
                    new DefaultDataTypeTextSerializer("text"))
                {
                    Hidden = false,
                    DefaultValue = new BusinessHours(),
                    HasConfigurableDefaultValue = false,
                }
            );
        }

        protected override void OnInit()
        {
            base.OnInit();

            // Makes the module accessible to the admin UI
            RegisterClientModule("xperiencecommunity", "web-locator");

            RegisterDefaultValueComponent("geolocation",
                AddressSelectorComponent.IDENTIFIER,
                ValidationHelper.GetValue<string>, value => ValidationHelper.GetValue<string>(value));
            
            RegisterDefaultValueComponent("geolocation",
                BusinessHoursSelectorComponent.IDENTIFIER,
                ValidationHelper.GetValue<string>, value => ValidationHelper.GetValue<string>(value));
        }
    }
}