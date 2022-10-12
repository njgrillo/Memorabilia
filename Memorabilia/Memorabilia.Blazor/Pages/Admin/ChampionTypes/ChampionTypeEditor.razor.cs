namespace Memorabilia.Blazor.Pages.Admin.ChampionTypes;

public partial class ChampionTypeEditor : EditDomainItem<ChampionType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetChampionType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveChampionType.Command(ViewModel));
    }
}
