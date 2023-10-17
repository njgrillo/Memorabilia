namespace Memorabilia.Blazor.Pages.Admin.Colleges;

public partial class ViewColleges 
    : ViewDomainItem<CollegesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveCollege(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new CollegesModel(await Mediator.Send(new GetColleges()));
    }
}
