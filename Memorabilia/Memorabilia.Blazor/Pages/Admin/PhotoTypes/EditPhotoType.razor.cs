namespace Memorabilia.Blazor.Pages.Admin.PhotoTypes;

public partial class EditPhotoType 
    : EditDomainItem<PhotoType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetPhotoType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SavePhotoType(EditModel));
    }
}
