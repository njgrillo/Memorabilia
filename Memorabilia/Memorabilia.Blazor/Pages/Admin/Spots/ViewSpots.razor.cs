namespace Memorabilia.Blazor.Pages.Admin.Spots;

public partial class ViewSpots 
    : ViewDomainItem<SpotsModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new Application.Features.Admin.Spots.SaveSpot(editModel));
    }

    public async Task OnLoad()
    {
        Model = new SpotsModel(await QueryRouter.Send(new GetSpots()));
    }
}
