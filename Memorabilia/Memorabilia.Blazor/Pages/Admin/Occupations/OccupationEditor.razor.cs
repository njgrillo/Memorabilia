namespace Memorabilia.Blazor.Pages.Admin.Occupations;

public partial class OccupationEditor : EditDomainItem<Occupation>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetOccupation(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveOccupation(Model));
    }
}
