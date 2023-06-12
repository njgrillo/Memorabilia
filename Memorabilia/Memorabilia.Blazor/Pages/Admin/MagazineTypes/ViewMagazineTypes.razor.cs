namespace Memorabilia.Blazor.Pages.Admin.MagazineTypes;

public partial class ViewMagazineTypes 
    : ViewDomainItem<MagazineTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveMagazineType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new MagazineTypesModel(await QueryRouter.Send(new GetMagazineTypes()));
    }
}
