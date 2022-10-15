#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.FigureSpecialtyTypes;

public partial class ViewFigureSpecialtyTypes : ViewDomainItem<FigureSpecialtyTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveFigureSpecialtyType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetFigureSpecialtyTypes.Query());
    }
}
