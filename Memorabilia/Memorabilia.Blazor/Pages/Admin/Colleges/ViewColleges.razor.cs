namespace Memorabilia.Blazor.Pages.Admin.Colleges;

public partial class ViewColleges 
    : ViewDomainItem<CollegesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveCollege(editModel));
    }

    public async Task OnLoad()
    {
        Model = new CollegesModel(await QueryRouter.Send(new GetColleges()));
    }
}
