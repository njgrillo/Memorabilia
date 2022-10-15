#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.BatTypes;

public partial class ViewBatTypes : ViewDomainItem<BatTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveBatType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetBatTypes.Query());
    }
}
