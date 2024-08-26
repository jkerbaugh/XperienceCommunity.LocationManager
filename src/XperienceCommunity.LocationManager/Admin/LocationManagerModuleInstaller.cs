using CMS.ContentEngine;
using CMS.DataEngine;
using CMS.FormEngine;
using CMS.Modules;
using XperienceCommunity.LocationManager;

namespace XperienceCommunity.Locator;

internal interface ILocationManagerModuleInstaller
{
    void Install();
}

internal class LocationManagerModuleInstaller() : ILocationManagerModuleInstaller
{
    public void Install()
    {
        
    }

    private void InstallHeadlessContentItem()
    {
        var info = DataClassInfoProvider.GetDataClassInfo(LocationInfo.OBJECT_TYPE) ??
                   DataClassInfo.New(LocationInfo.OBJECT_TYPE);
        
        
        // SetFormDefinition(info);
        if(info.HasChanged)
            DataClassInfoProvider.SetDataClassInfo(info);
    }
    

    /// <summary>
    /// Ensure that the form is not upserted with any existing form
    /// </summary>
    /// <param name="info"></param>
    /// <param name="form"></param>
    private static void SetFormDefinition(DataClassInfo info, FormInfo form)
    {
        if (info.ClassID > 0)
        {
            var existingForm = new FormInfo(info.ClassFormDefinition);
            existingForm.CombineWithForm(form, new());
            info.ClassFormDefinition = existingForm.GetXmlDefinition();
        }
        else
        {
            info.ClassFormDefinition = form.GetXmlDefinition();
        }
    }
}