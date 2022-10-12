namespace Memorabilia.Blazor.Pages.Admin.MagazineTypes;

public partial class MagazineTypeEditor : EditDomainItem<MagazineType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetMagazineType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveMagazineType.Command(ViewModel));
    }
}
