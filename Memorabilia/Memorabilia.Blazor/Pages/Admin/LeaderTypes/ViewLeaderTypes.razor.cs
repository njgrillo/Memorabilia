namespace Memorabilia.Blazor.Pages.Admin.LeaderTypes;

public partial class ViewLeaderTypes : ViewDomainItem<LeaderTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{   
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveLeaderType(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetLeaderTypes());
    }
}
