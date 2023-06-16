namespace Memorabilia.Blazor.Pages.Admin.MagazineTypes;

public partial class ViewMagazineTypes 
    : ViewDomainItem<MagazineTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveMagazineType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new MagazineTypesModel(await QueryRouter.Send(new GetMagazineTypes()));
    }
}
