namespace Memorabilia.Blazor.Pages.Admin.Sizes;

public partial class ViewSizes : ViewDomainItem<SizesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SaveSize.Command(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetSizes.Query());
    }
}
