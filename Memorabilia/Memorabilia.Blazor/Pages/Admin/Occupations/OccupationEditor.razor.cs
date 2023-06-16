namespace Memorabilia.Blazor.Pages.Admin.Occupations;

public partial class OccupationEditor 
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
