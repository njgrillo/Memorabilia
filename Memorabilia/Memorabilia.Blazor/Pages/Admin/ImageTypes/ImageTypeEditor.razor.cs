namespace Memorabilia.Blazor.Pages.Admin.ImageTypes;

public partial class ImageTypeEditor : EditDomainItem<ImageType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetImageType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveImageType.Command(ViewModel));
    }
}
