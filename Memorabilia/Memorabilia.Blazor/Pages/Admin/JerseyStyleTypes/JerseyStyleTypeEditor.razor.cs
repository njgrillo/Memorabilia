namespace Memorabilia.Blazor.Pages.Admin.JerseyStyleTypes;

public partial class JerseyStyleTypeEditor 
    : EditDomainItem<JerseyStyleType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetJerseyStyleType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveJerseyStyleType(EditModel));
    }
}
