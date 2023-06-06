namespace Memorabilia.Blazor.Pages.Admin.MagazineTypes;

public partial class ViewMagazineTypes : ViewDomainItem<MagazineTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveMagazineType(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetMagazineTypes());
    }
}
