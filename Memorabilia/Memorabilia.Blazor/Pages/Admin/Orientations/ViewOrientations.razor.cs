namespace Memorabilia.Blazor.Pages.Admin.Orientations
{
    public partial class ViewOrientations : ViewDomainItem<OrientationsViewModel>, IDeleteDomainItem, IViewDomainItem
    {
        public async Task OnDelete(DomainEditModel viewModel)
        {
            await OnDelete(new SaveOrientation(viewModel));
        }

        public async Task OnLoad()
        {
            await OnLoad(new GetOrientations());
        }
    }
}
