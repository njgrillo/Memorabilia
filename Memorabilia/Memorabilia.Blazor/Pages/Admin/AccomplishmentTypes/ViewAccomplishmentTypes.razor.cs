namespace Memorabilia.Blazor.Pages.Admin.AccomplishmentTypes;

public partial class ViewAccomplishmentTypes : ViewDomainItem<AccomplishmentTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SaveAccomplishmentTypeCommand(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetAccomplishmentTypesQuery());
    }
}
