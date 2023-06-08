namespace Memorabilia.Blazor.Pages.Admin.AwardTypes;

public partial class ViewAwardTypes : ViewDomainItem<AwardTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveAwardType(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetAwardTypes());
    }
}
