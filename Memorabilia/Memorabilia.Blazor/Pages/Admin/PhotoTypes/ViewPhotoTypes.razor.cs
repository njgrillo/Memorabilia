namespace Memorabilia.Blazor.Pages.Admin.PhotoTypes;

public partial class ViewPhotoTypes 
    : ViewDomainItem<PhotoTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SavePhotoType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new PhotoTypesModel(await QueryRouter.Send(new GetPhotoTypes()));
    }
}
