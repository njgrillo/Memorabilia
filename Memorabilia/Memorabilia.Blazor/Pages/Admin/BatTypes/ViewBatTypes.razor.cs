namespace Memorabilia.Blazor.Pages.Admin.BatTypes;

public partial class ViewBatTypes 
    : ViewDomainItem<BatTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveBatType(editModel));
    }
    protected override async Task OnInitializedAsync()
    {
        Model = new BatTypesModel(await QueryRouter.Send(new GetBatTypes()));
    }
}
