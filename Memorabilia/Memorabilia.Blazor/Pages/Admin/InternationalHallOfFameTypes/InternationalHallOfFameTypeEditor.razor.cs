namespace Memorabilia.Blazor.Pages.Admin.InternationalHallOfFameTypes;

public partial class InternationalHallOfFameTypeEditor 
    : EditDomainItem<InternationalHallOfFameType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetInternationalHallOfFameType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveInternationalHallOfFameType(EditModel));
    }
}
