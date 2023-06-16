namespace Memorabilia.Blazor.Pages.Admin.Spots;

public partial class ViewSpots 
    : ViewDomainItem<SpotsModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new Application.Features.Admin.Spots.SaveSpot(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new SpotsModel(await QueryRouter.Send(new GetSpots()));
    }
}
