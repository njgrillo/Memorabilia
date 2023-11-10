namespace Memorabilia.Blazor.Pages.Admin.Occupations;

public partial class EditOccupation
    : EditDomainItem<Occupation>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetOccupation(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveOccupation(EditModel));
    }
}
