namespace Memorabilia.Blazor.Pages.Admin.GloveTypes;

public partial class ViewGloveTypes 
    : ViewDomainItem<GloveTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveGloveType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new GloveTypesModel(await QueryRouter.Send(new GetGloveTypes()));
    }
}
