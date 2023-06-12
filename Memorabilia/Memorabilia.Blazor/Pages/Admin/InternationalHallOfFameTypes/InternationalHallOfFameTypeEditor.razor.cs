namespace Memorabilia.Blazor.Pages.Admin.InternationalHallOfFameTypes;

public partial class InternationalHallOfFameTypeEditor 
    : EditDomainItem<InternationalHallOfFameType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetInternationalHallOfFameType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveInternationalHallOfFameType(Model));
    }
}
