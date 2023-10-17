namespace Memorabilia.Blazor.Pages.Admin.PriorityTypes
{
    public partial class ViewPriorityTypes 
        : ViewDomainItem<PriorityTypesModel>
    {
        public async Task OnDelete(DomainEditModel editModel)
        {
            await OnDelete(new SavePriorityType(editModel));
        }

        protected override async Task OnInitializedAsync()
        {
            Model = new PriorityTypesModel(await Mediator.Send(new GetPriorityTypes()));
        }
    }
}
