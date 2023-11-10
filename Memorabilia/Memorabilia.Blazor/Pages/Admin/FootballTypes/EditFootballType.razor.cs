namespace Memorabilia.Blazor.Pages.Admin.FootballTypes;

public partial class EditFootballType
    : EditDomainItem<FootballType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetFootballType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveFootballType(EditModel));
    }
}
