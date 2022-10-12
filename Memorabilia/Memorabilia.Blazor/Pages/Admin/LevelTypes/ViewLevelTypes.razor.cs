namespace Memorabilia.Blazor.Pages.Admin.LevelTypes;

public partial class ViewLevelTypes : ViewDomainItem<LevelTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SaveLevelType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetLevelTypes.Query());
    }
}
