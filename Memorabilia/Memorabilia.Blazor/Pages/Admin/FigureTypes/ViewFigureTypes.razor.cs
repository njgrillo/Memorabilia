namespace Memorabilia.Blazor.Pages.Admin.FigureTypes;

public partial class ViewFigureTypes 
    : ViewDomainItem<FigureTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveFigureType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new FigureTypesModel(await QueryRouter.Send(new GetFigureTypes()));
    }
}
