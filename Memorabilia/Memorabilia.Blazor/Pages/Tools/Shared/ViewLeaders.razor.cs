namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewLeaders 
    : ViewSportTools<LeaderModel>
{
    protected LeadersModel Model 
        = new();

    protected async Task Browse()
    {
        var parameters = new DialogParameters
        {
            ["DomainItems"] = LeaderType.GetAll(Sport),
            ["Title"] = $"{Sport.Name} Leader Types"
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<DomainItemBrowseDialog>(string.Empty, parameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        _ = result.Data.ToString().TryParse(out int id);

        if (id == 0)
            return;

        var leaderType = LeaderType.Find(id);

        await Load(leaderType);
    }

    private async Task Load(LeaderType leaderType)
    {
        if (leaderType == null)
            return;

        Model = new(await Mediator.Send(new GetLeaders(leaderType, Sport)), Sport)
                {
                    LeaderType = leaderType
                };
    }

    private async Task OnInputChange(LeaderType leaderType)
    {
        Model = new(await Mediator.Send(new GetLeaders(leaderType, Sport)), Sport)
                {
                    LeaderType = leaderType
                };
    }
}
