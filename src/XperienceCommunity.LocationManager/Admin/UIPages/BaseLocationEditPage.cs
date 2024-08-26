using CMS.DataEngine;
using Kentico.Xperience.Admin.Base;
using Kentico.Xperience.Admin.Base.Forms;
using XperienceCommunity.LocationManager;
using XperienceCommunity.Locator.Models;
using IFormItemCollectionProvider = Kentico.Xperience.Admin.Base.Forms.Internal.IFormItemCollectionProvider;

namespace XperienceCommunity.Locator;

public class BaseLocationEditPage(
    IFormItemCollectionProvider formItemCollectionProvider,
    IFormDataBinder formDataBinder)
    : ModelEditPage<LocationConfigurationModel>(formItemCollectionProvider, formDataBinder)
{
    
    private LocationConfigurationModel? model;
    protected override LocationConfigurationModel Model => model ??= new();
    

    // protected override async Task<ICommandResponse> ProcessFormData(
    //     LocationConfigurationModel model,
    //     ICollection<IFormItem> formItems)
    // {
    //     var info = new LocationInfo();
    //
    //     model.MapToLocationInfo(info);
    //
    //     channelCodeSnippetInfoProvider.Set(info);
    //
    //     return await base.ProcessFormData(model, formItems);
    // }

}