namespace Memorabilia.Blazor.Pages.Admin.Occupations;

public partial class ViewOccupations 
    : ViewDomainItem<OccupationsModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveOccupation(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new OccupationsModel(await QueryRouter.Send(new GetOccupations()));
    }
}
