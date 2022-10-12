namespace Memorabilia.Blazor.Pages.Admin.MagazineTypes;

public partial class ViewMagazineTypes : ViewDomainItem<MagazineTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SaveMagazineType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetMagazineTypes.Query());
    }
}
