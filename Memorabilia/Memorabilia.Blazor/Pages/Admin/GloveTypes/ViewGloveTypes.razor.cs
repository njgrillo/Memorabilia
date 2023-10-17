namespace Memorabilia.Blazor.Pages.Admin.GloveTypes;

public partial class ViewGloveTypes 
    : ViewDomainItem<GloveTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveGloveType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new GloveTypesModel(await Mediator.Send(new GetGloveTypes()));
    }
}
