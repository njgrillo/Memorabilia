namespace Memorabilia.Blazor.Pages.Admin.BatTypes;

public partial class EditBatType
    : EditDomainItem<BatType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetBatType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveBatType(EditModel));
    }
}
