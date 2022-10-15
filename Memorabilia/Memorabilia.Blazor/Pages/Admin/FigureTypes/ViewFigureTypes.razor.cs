#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.FigureTypes;

public partial class ViewFigureTypes : ViewDomainItem<FigureTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveFigureType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetFigureTypes.Query());
    }
}
