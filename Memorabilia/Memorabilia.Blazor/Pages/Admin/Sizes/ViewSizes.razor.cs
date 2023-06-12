namespace Memorabilia.Blazor.Pages.Admin.Sizes;

public partial class ViewSizes 
    : ViewDomainItem<SizesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveSize(editModel));
    }

    public async Task OnLoad()
    {
        Model = new SizesModel(await QueryRouter.Send(new GetSizes()));
    }
}
