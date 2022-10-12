namespace Memorabilia.Blazor.Pages.Admin.Orientations
{
    public partial class ViewOrientations : ViewDomainItem<OrientationsViewModel>, IDeleteDomainItem, IViewDomainItem
    {
        public async Task OnDelete(SaveDomainViewModel viewModel)
        {
            await OnDelete(new SaveOrientation.Command(viewModel));
        }

        public async Task OnLoad()
        {
            await OnLoad(new GetOrientations.Query());
        }
    }
}
