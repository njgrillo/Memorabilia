namespace Memorabilia.Blazor.Pages.Admin.FigureSpecialtyTypes;

public partial class ViewFigureSpecialtyTypes 
    : ViewDomainItem<FigureSpecialtyTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveFigureSpecialtyType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new FigureSpecialtyTypesModel(await QueryRouter.Send(new GetFigureSpecialtyTypes()));
    }
}
