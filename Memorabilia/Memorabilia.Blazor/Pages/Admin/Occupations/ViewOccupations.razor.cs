namespace Memorabilia.Blazor.Pages.Admin.Occupations;

public partial class ViewOccupations : ViewDomainItem<OccupationsViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SaveOccupation(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetOccupations());
    }
}
