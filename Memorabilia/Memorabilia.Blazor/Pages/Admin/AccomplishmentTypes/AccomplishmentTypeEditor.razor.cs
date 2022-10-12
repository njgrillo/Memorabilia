namespace Memorabilia.Blazor.Pages.Admin.AccomplishmentTypes;

public partial class AccomplishmentTypeEditor : EditDomainItem<AccomplishmentType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetAccomplishmentType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveAccomplishmentType.Command(ViewModel));
    }
}
