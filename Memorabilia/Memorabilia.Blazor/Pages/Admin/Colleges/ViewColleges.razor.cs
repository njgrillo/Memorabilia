namespace Memorabilia.Blazor.Pages.Admin.Colleges;

public partial class ViewColleges 
    : ViewDomainItem<CollegesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveCollege(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new CollegesModel(await QueryRouter.Send(new GetColleges()));
    }
}
