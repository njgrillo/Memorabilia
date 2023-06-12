namespace Memorabilia.Blazor.Pages.Admin.ImageTypes;

public partial class ViewImageTypes 
    : ViewDomainItem<ImageTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveImageType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new ImageTypesModel(await QueryRouter.Send(new GetImageTypes()));
    }
}
