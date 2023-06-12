namespace Memorabilia.Blazor.Pages.Admin.Occupations;

public partial class ViewOccupations 
    : ViewDomainItem<OccupationsModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveOccupation(editModel));
    }

    public async Task OnLoad()
    {
        Model = new OccupationsModel(await QueryRouter.Send(new GetOccupations()));
    }
}
