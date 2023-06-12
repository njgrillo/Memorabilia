namespace Memorabilia.Blazor.Pages.Admin.Spots;

public partial class ViewSpots 
    : ViewDomainItem<SpotsModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new Application.Features.Admin.Spots.SaveSpot(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new SpotsModel(await QueryRouter.Send(new GetSpots()));
    }
}
