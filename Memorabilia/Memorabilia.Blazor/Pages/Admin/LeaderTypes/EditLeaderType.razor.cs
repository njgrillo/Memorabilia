namespace Memorabilia.Blazor.Pages.Admin.LeaderTypes;

public partial class EditLeaderType
    : EditDomainItem<LeaderType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetLeaderType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveLeaderType(EditModel));
    }
}
