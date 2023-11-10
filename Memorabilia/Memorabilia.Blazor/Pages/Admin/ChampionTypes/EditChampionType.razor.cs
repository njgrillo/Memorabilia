namespace Memorabilia.Blazor.Pages.Admin.ChampionTypes;

public partial class EditChampionType
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
