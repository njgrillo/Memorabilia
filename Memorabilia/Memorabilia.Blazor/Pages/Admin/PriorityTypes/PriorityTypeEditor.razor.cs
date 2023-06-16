namespace Memorabilia.Blazor.Pages.Admin.PriorityTypes;

public partial class PriorityTypeEditor 
    : EditDomainItem<PriorityType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetPriorityType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SavePriorityType(EditModel));
    }
}
