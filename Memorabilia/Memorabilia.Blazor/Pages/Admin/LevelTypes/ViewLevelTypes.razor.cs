namespace Memorabilia.Blazor.Pages.Admin.LevelTypes;

public partial class ViewLevelTypes : ViewDomainItem<LevelTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveLevelType(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetLevelTypes());
    }
}
