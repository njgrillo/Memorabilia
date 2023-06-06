namespace Memorabilia.Blazor.Pages.Admin.AccomplishmentTypes;

public partial class ViewAccomplishmentTypes : ViewDomainItem<AccomplishmentTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveAccomplishmentType(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetAccomplishmentTypes());
    }
}
