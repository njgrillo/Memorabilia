namespace Memorabilia.Blazor.Pages.Admin.Spots;

public partial class ViewSpots : ViewDomainItem<SpotsViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new Application.Features.Admin.Spots.SaveSpot.Command(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetSpots.Query());
    }
}
