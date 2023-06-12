namespace Memorabilia.Blazor.Pages.Admin.PhotoTypes;

public partial class ViewPhotoTypes 
    : ViewDomainItem<PhotoTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SavePhotoType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new PhotoTypesModel(await QueryRouter.Send(new GetPhotoTypes()));
    }
}
