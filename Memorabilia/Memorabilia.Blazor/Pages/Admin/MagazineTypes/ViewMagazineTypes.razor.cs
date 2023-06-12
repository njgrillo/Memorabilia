namespace Memorabilia.Blazor.Pages.Admin.MagazineTypes;

public partial class ViewMagazineTypes 
    : ViewDomainItem<MagazineTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveMagazineType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new MagazineTypesModel(await QueryRouter.Send(new GetMagazineTypes()));
    }
}
