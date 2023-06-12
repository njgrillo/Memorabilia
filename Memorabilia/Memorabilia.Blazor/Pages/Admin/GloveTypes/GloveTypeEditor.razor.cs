namespace Memorabilia.Blazor.Pages.Admin.GloveTypes;

public partial class GloveTypeEditor 
    : EditDomainItem<GloveType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetGloveType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveGloveType(EditModel));
    }
}
