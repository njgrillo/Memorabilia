#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.BammerTypes;

public partial class ViewBammerTypes : ViewDomainItem<BammerTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SaveBammerType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetBammerTypes.Query());
    }
}
