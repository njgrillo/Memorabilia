namespace Memorabilia.Blazor.Pages.Admin.PriorityTypes
{
    public partial class ViewPriorityTypes 
        : ViewDomainItem<PriorityTypesModel>, IDeleteDomainItem, IViewDomainItem
    {
        public async Task OnDelete(DomainEditModel editModel)
        {
            await OnDelete(new SavePriorityType(editModel));
        }

        public async Task OnLoad()
        {
            Model = new PriorityTypesModel(await QueryRouter.Send(new GetPriorityTypes()));
        }
    }
}
