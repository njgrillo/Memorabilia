namespace Memorabilia.Blazor.Pages.Admin.PhotoTypes;

public partial class PhotoTypeEditor : EditDomainItem<PhotoType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetPhotoType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SavePhotoType.Command(ViewModel));
    }
}
