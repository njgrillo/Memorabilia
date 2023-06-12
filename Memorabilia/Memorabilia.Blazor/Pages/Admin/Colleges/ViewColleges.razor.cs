namespace Memorabilia.Blazor.Pages.Admin.Colleges;

public partial class ViewColleges 
    : ViewDomainItem<CollegesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveCollege(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new CollegesModel(await QueryRouter.Send(new GetColleges()));
    }
}
