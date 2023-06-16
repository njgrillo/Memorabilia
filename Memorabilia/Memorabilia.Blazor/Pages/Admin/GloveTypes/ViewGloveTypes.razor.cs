namespace Memorabilia.Blazor.Pages.Admin.GloveTypes;

public partial class ViewGloveTypes 
    : ViewDomainItem<GloveTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveGloveType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new GloveTypesModel(await QueryRouter.Send(new GetGloveTypes()));
    }
}
