namespace Memorabilia.Blazor.Pages.Admin.BammerTypes;

public partial class EditBammerType
    : EditDomainItem<BammerType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetBammerType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveBammerType(EditModel));
    }
}
