namespace Memorabilia.Blazor.Pages.Admin.Colors;

public partial class ColorEditor 
    : EditDomainItem<Constant.Color>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetColor(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveColor(EditModel));
    }
}
