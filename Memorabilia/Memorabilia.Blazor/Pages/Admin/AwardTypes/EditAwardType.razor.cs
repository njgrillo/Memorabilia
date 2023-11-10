namespace Memorabilia.Blazor.Pages.Admin.AwardTypes;

public partial class EditAwardType
    : EditDomainItem<AwardType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetAwardType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveAwardType(EditModel));
    }
}
