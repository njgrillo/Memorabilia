namespace Memorabilia.Blazor.Pages.Admin.InternationalHallOfFameTypes;

public partial class ViewInternationalHallOfFameTypes 
    : ViewDomainItem<InternationalHallOfFameTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveInternationalHallOfFameType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new InternationalHallOfFameTypesModel(await QueryRouter.Send(new GetInternationalHallOfFameTypes()));
    }
}
