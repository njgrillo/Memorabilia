namespace Memorabilia.Blazor.Pages.Admin.BaseballTypes;

public partial class ViewBaseballTypes : ViewDomainItem<BaseballTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveBaseballType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new BaseballTypesModel(await QueryRouter.Send(new GetBaseballTypes()));
    }
}
