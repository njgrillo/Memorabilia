namespace Memorabilia.Blazor.Pages.Admin.PriorityTypes
{
    public partial class ViewPriorityTypes : ViewDomainItem<PriorityTypesViewModel>, IDeleteDomainItem, IViewDomainItem
    {
        public async Task OnDelete(DomainEditModel viewModel)
        {
            await OnDelete(new SavePriorityType(viewModel));
        }

        public async Task OnLoad()
        {
            await OnLoad(new GetPriorityTypes());
        }
    }
}
