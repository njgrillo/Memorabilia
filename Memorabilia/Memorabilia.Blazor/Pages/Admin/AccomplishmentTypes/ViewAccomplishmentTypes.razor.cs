namespace Memorabilia.Blazor.Pages.Admin.AccomplishmentTypes;

public partial class ViewAccomplishmentTypes : ViewDomainItem<AccomplishmentTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SaveAccomplishmentType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetAccomplishmentTypes.Query());
    }
}
