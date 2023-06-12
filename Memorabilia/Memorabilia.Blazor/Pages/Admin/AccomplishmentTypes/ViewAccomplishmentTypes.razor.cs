namespace Memorabilia.Blazor.Pages.Admin.AccomplishmentTypes;

public partial class ViewAccomplishmentTypes 
    : ViewDomainItem<AccomplishmentTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveAccomplishmentType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new AccomplishmentTypesModel(await QueryRouter.Send(new GetAccomplishmentTypes()));
    }
}
