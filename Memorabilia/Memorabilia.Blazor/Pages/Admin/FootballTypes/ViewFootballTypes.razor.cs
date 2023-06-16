namespace Memorabilia.Blazor.Pages.Admin.FootballTypes;

public partial class ViewFootballTypes 
    : ViewDomainItem<FootballTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveFootballType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new FootballTypesModel(await QueryRouter.Send(new GetFootballTypes()));
    }
}
