#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.ImageTypes;

public partial class ViewImageTypes : ComponentBase, IViewDomainItem, IDeleteDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private ImageTypesViewModel ViewModel;

    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveImageType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetImageTypes.Query()).ConfigureAwait(false);
    }
}
