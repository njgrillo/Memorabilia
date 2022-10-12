namespace Memorabilia.Blazor.Pages.Admin.PriorityTypes
{
    public partial class ViewPriorityTypes : ViewDomainItem<PriorityTypesViewModel>, IDeleteDomainItem, IViewDomainItem
    {
        public async Task OnDelete(SaveDomainViewModel viewModel)
        {
            await OnDelete(new SavePriorityType.Command(viewModel));
        }

        public async Task OnLoad()
        {
            await OnLoad(new GetPriorityTypes.Query());
        }
    }
}
