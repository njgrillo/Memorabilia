namespace Memorabilia.Blazor.Pages.Admin.JerseyTypes;

public partial class ViewJerseyTypes 
    : ViewDomainItem<JerseyTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveJerseyType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new JerseyTypesModel(await Mediator.Send(new GetJerseyTypes()));
    }
}
