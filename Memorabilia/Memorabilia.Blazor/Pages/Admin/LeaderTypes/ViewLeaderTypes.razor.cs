#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.LeaderTypes;

public partial class ViewLeaderTypes : ViewDomainItem<LeaderTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{   
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SaveLeaderType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetLeaderTypes.Query());
    }
}
