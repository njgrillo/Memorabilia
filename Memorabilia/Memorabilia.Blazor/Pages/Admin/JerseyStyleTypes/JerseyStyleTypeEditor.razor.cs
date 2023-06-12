namespace Memorabilia.Blazor.Pages.Admin.JerseyStyleTypes;

public partial class JerseyStyleTypeEditor 
    : EditDomainItem<JerseyStyleType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetJerseyStyleType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveJerseyStyleType(Model));
    }
}
