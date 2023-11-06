namespace Memorabilia.Blazor.Pages.Admin.GloveTypes;

public partial class EditGloveType 
    : EditDomainItem<GloveType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetGloveType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveGloveType(EditModel));
    }
}
