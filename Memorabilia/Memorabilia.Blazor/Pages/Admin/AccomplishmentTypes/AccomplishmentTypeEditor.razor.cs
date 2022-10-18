namespace Memorabilia.Blazor.Pages.Admin.AccomplishmentTypes;

public partial class AccomplishmentTypeEditor : EditDomainItem<AccomplishmentType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetAccomplishmentType(Id));
        //await OnLoad(new GetDomainItem<Domain.Entities.AccomplishmentType>(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveAccomplishmentType(ViewModel));
        //await OnSave(new SaveDomainItem<Domain.Entities.AccomplishmentType>(ViewModel));
    }
}
