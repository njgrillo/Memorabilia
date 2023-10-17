namespace Memorabilia.Blazor.Pages.Admin.AccomplishmentTypes;

public partial class ViewAccomplishmentTypes 
    : ViewDomainItem<AccomplishmentTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveAccomplishmentType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new AccomplishmentTypesModel(await Mediator.Send(new GetAccomplishmentTypes()));
    }
}
