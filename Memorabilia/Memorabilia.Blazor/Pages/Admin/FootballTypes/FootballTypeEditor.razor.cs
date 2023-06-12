namespace Memorabilia.Blazor.Pages.Admin.FootballTypes;

public partial class FootballTypeEditor 
    : EditDomainItem<FootballType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetFootballType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveFootballType(EditModel));
    }
}
