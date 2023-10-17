namespace Memorabilia.Blazor.Pages.Admin.Orientations;

public partial class ViewOrientations 
    : ViewDomainItem<OrientationsModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveOrientation(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new OrientationsModel(await Mediator.Send(new GetOrientations()));
    }
}
