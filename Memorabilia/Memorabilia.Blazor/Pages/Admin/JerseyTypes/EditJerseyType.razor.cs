namespace Memorabilia.Blazor.Pages.Admin.JerseyTypes;

public partial class EditJerseyType
    : EditDomainItem<JerseyType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetJerseyType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveJerseyType(EditModel));
    }
}
