namespace Memorabilia.Blazor.Pages.Admin.ImageTypes;

public partial class ViewImageTypes : ViewDomainItem<ImageTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveImageType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetImageTypes());
    }
}
