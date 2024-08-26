using Kentico.Xperience.Admin.Base.Forms;

namespace XperienceCommunity.Locator.FormComponents;

internal class AddressSelectorConfiguration : FormComponentConfigurator<AddressSelectorComponent>
{
    public override Task Configure(AddressSelectorComponent formComponent, IFormFieldValueProvider formFieldValueProvider,
        CancellationToken cancellationToken)
    {

        return Task.CompletedTask;
    }
}