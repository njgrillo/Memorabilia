namespace Memorabilia.Blazor.Pages.Admin.FigureTypes;

public partial class ViewFigureTypes 
    : ViewDomainItem<FigureTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveFigureType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new FigureTypesModel(await QueryRouter.Send(new GetFigureTypes()));
    }
}
