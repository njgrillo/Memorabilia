namespace Memorabilia.Blazor.Pages.Admin.Colleges;

public partial class ViewColleges : ViewDomainItem<CollegesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveCollege(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetColleges());
    }
}
