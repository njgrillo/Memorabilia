namespace Memorabilia.Blazor.Pages.Admin.AccomplishmentTypes;

public partial class AccomplishmentTypeEditor 
    : EditDomainItem<AccomplishmentType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetAccomplishmentType(Id));
    }

    public async Task OnSave()
    {     
        await OnSave(new SaveAccomplishmentType(EditModel));
    }
}
