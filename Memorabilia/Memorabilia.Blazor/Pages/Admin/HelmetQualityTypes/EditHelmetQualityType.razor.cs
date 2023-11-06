namespace Memorabilia.Blazor.Pages.Admin.HelmetQualityTypes;

public partial class EditHelmetQualityType
    : EditDomainItem<HelmetQualityType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetHelmetQualityType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveHelmetQualityType(EditModel));
    }
}
