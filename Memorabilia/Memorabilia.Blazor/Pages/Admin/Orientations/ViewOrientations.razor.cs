namespace Memorabilia.Blazor.Pages.Admin.Orientations
{
    public partial class ViewOrientations 
        : ViewDomainItem<OrientationsModel>, IDeleteDomainItem, IViewDomainItem
    {
        public async Task OnDelete(DomainEditModel viewModel)
        {
            await OnDelete(new SaveOrientation(viewModel));
        }

        public async Task OnLoad()
        {
            ViewModel = new OrientationsModel(await QueryRouter.Send(new GetOrientations()));
        }
    }
}
