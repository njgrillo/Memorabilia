namespace Memorabilia.Blazor.Pages.Admin.BaseballTypes;

public partial class ViewBaseballTypes 
    : ViewDomainItem<BaseballTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveBaseballType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new BaseballTypesModel(await QueryRouter.Send(new GetBaseballTypes()));
    }
}
