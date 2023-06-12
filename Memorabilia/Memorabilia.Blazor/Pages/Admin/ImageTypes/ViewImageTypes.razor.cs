namespace Memorabilia.Blazor.Pages.Admin.ImageTypes;

public partial class ViewImageTypes 
    : ViewDomainItem<ImageTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveImageType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new ImageTypesModel(await QueryRouter.Send(new GetImageTypes()));
    }
}
