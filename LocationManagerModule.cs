using CMS;
using CMS.Base;
using CMS.Core;
using CMS.DataEngine;
using Microsoft.Extensions.DependencyInjection;
using XperienceCommunity.Locator;
using XperienceCommunity.Locator.DataTypes;

[assembly: RegisterModule(typeof(LocationManagerModule))]

namespace XperienceCommunity.Locator;

public class LocationManagerModule() : Module("XperienceCommunity.LocationManager")
{
    private ILocationManagerModuleInstaller? mInstaller;
    
    protected override void OnInit(ModuleInitParameters parameters)
    {
        base.OnInit(parameters);

        var services = parameters.Services;
        
        mInstaller = services.GetRequiredService<ILocationManagerModuleInstaller>();

        ApplicationEvents.Initialized.Execute += InitializeModule;
    }

    private void InitializeModule(object? sender, EventArgs e) => mInstaller?.Install();
}