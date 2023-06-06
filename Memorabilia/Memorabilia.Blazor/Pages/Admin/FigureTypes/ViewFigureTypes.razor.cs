namespace Memorabilia.Blazor.Pages.Admin.FigureTypes;

public partial class ViewFigureTypes : ViewDomainItem<FigureTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveFigureType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetFigureTypes());
    }
}
