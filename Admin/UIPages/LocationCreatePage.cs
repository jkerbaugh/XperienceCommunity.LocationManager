using Kentico.Xperience.Admin.Base;
using Kentico.Xperience.Admin.Base.Forms;
using XperienceCommunity.Locator;
using IFormItemCollectionProvider = Kentico.Xperience.Admin.Base.Forms.Internal.IFormItemCollectionProvider;

[assembly: UIPage(
    typeof(LocationListingPage),
    "create",
    typeof(LocationCreatePage),
    name: "Create Location",
    templateName: TemplateNames.EDIT,
    order: UIPageOrder.NoOrder
)]

namespace XperienceCommunity.Locator;

public class LocationCreatePage(IFormItemCollectionProvider formItemCollectionProvider, IFormDataBinder formDataBinder) 
    : BaseLocationEditPage(formItemCollectionProvider, formDataBinder)
{
    
}