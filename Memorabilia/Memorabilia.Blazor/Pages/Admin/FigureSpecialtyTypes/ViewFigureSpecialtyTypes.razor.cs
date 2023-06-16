namespace Memorabilia.Blazor.Pages.Admin.FigureSpecialtyTypes;

public partial class ViewFigureSpecialtyTypes 
    : ViewDomainItem<FigureSpecialtyTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveFigureSpecialtyType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new FigureSpecialtyTypesModel(await QueryRouter.Send(new GetFigureSpecialtyTypes()));
    }
}
