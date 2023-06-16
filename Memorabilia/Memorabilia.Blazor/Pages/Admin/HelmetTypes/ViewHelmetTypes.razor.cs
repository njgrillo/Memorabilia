namespace Memorabilia.Blazor.Pages.Admin.HelmetTypes;

public partial class ViewHelmetTypes 
    : ViewDomainItem<HelmetTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveHelmetType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new HelmetTypesModel(await QueryRouter.Send(new GetHelmetTypes()));
    }
}
