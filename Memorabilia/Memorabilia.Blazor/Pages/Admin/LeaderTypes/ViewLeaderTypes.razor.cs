namespace Memorabilia.Blazor.Pages.Admin.LeaderTypes;

public partial class ViewLeaderTypes 
    : ViewDomainItem<LeaderTypesModel>, IDeleteDomainItem, IViewDomainItem
{   
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveLeaderType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new LeaderTypesModel(await QueryRouter.Send(new GetLeaderTypes()));
    }
}
