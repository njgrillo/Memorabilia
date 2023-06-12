namespace Memorabilia.Blazor.Pages.Admin.Colors;

public partial class ColorEditor : EditDomainItem<Constant.Color>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetColor(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveColor(ViewModel));
    }
}
