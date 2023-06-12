namespace Memorabilia.Blazor.Pages.Admin.PhotoTypes;

public partial class ViewPhotoTypes 
    : ViewDomainItem<PhotoTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SavePhotoType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new PhotoTypesModel(await QueryRouter.Send(new GetPhotoTypes()));
    }
}
