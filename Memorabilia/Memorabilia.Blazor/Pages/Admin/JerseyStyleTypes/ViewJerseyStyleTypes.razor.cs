namespace Memorabilia.Blazor.Pages.Admin.JerseyStyleTypes;

public partial class ViewJerseyStyleTypes 
    : ViewDomainItem<JerseyStyleTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveJerseyStyleType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new JerseyStyleTypesModel(await QueryRouter.Send(new GetJerseyStyleTypes()));
    }
}
