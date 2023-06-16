namespace Memorabilia.Blazor.Pages.Admin.ChampionTypes;

public partial class ChampionTypeEditor 
    : EditDomainItem<ChampionType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetChampionType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveChampionType(EditModel));
    }
}
