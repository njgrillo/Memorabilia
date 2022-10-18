namespace Memorabilia.Blazor.Pages.Admin.PhotoTypes;

public partial class ViewPhotoTypes : ViewDomainItem<PhotoTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SavePhotoType(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetPhotoTypes());
    }
}
