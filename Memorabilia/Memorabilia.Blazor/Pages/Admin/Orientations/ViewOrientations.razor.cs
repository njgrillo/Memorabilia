namespace Memorabilia.Blazor.Pages.Admin.Orientations
{
    public partial class ViewOrientations 
        : ViewDomainItem<OrientationsModel>, IDeleteDomainItem, IViewDomainItem
    {
        public async Task OnDelete(DomainEditModel editModel)
        {
            await OnDelete(new SaveOrientation(editModel));
        }

        public async Task OnLoad()
        {
            Model = new OrientationsModel(await QueryRouter.Send(new GetOrientations()));
        }
    }
}
