namespace Memorabilia.Blazor.Pages.Admin.ThroughTheMailFailureTypes;

public partial class ThroughTheMailFailureTypeEditor
    : EditDomainItem<ThroughTheMailFailureType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetThroughTheMailFailureType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveThroughTheMailFailureType(EditModel));
    }
}
