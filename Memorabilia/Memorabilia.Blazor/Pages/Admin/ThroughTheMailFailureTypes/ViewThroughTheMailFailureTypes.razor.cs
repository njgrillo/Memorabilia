namespace Memorabilia.Blazor.Pages.Admin.ThroughTheMailFailureTypes;

public partial class ViewThroughTheMailFailureTypes
    : ViewDomainItem<ThroughTheMailFailureTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveThroughTheMailFailureType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new ThroughTheMailFailureTypesModel(await Mediator.Send(new GetThroughTheMailFailureTypes()));
    }
}
