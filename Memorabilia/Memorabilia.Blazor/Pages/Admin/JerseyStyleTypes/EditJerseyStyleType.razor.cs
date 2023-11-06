namespace Memorabilia.Blazor.Pages.Admin.JerseyStyleTypes;

public partial class EditJerseyStyleType
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
