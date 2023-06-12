namespace Memorabilia.Blazor.Pages.Admin.PriorityTypes
{
    public partial class ViewPriorityTypes 
        : ViewDomainItem<PriorityTypesModel>, IDeleteDomainItem, IViewDomainItem
    {
        public async Task OnDelete(DomainEditModel editModel)
        {
            await OnDelete(new SavePriorityType(viewModel));
        }

        public async Task OnLoad()
        {
            ViewModel= new PriorityTypesModel(await QueryRouter.Send(new GetPriorityTypes()));
        }
    }
}
