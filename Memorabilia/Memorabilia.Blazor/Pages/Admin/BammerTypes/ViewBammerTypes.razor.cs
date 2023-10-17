namespace Memorabilia.Blazor.Pages.Admin.BammerTypes;

public partial class ViewBammerTypes 
    : ViewDomainItem<BammerTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveBammerType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new BammerTypesModel(await Mediator.Send(new GetBammerTypes()));
    }
}
