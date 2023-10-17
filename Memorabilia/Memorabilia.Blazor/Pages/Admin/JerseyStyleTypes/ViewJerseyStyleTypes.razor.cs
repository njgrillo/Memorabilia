namespace Memorabilia.Blazor.Pages.Admin.JerseyStyleTypes;

public partial class ViewJerseyStyleTypes 
    : ViewDomainItem<JerseyStyleTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveJerseyStyleType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new JerseyStyleTypesModel(await Mediator.Send(new GetJerseyStyleTypes()));
    }
}
