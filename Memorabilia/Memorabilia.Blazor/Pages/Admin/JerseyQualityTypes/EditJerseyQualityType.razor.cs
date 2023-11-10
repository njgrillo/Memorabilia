namespace Memorabilia.Blazor.Pages.Admin.JerseyQualityTypes;

public partial class EditJerseyQualityType
    : EditDomainItem<JerseyQualityType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetJerseyQualityType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveJerseyQualityType(EditModel));
    }
}
