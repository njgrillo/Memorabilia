namespace Memorabilia.Blazor.Pages.Admin.FigureTypes;

public partial class ViewFigureTypes 
    : ViewDomainItem<FigureTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveFigureType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new FigureTypesModel(await QueryRouter.Send(new GetFigureTypes()));
    }
}
