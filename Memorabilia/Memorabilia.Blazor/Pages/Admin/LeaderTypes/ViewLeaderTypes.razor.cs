namespace Memorabilia.Blazor.Pages.Admin.LeaderTypes;

public partial class ViewLeaderTypes 
    : ViewDomainItem<LeaderTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveLeaderType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new LeaderTypesModel(await Mediator.Send(new GetLeaderTypes()));
    }
}
