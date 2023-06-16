namespace Memorabilia.Blazor.Pages.Admin.MagazineTypes;

public partial class MagazineTypeEditor 
    : EditDomainItem<MagazineType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetMagazineType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveMagazineType(EditModel));
    }
}
