namespace Memorabilia.Blazor.Pages.Admin.FigureSpecialtyTypes;

public partial class ViewFigureSpecialtyTypes : ViewDomainItem<FigureSpecialtyTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveFigureSpecialtyType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetFigureSpecialtyTypes());
    }
}
