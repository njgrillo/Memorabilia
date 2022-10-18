using Memorabilia.Application.Features.Admin.Teams;

namespace Memorabilia.Web.Pages.Admin.Teams;

public partial class EditTeamDivision : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public int SportLeagueLevelId { get; set; }

    [Parameter]
    public int TeamId { get; set; }

    private SaveTeamDivisionsViewModel _viewModel = new();        

    protected async Task OnLoad()
    {
        _viewModel = new SaveTeamDivisionsViewModel(TeamId);

        var divisions = (await QueryRouter.Send(new GetTeamDivisions(TeamId))
                                          .ConfigureAwait(false)).Select(teamDivision => new SaveTeamDivisionViewModel(teamDivision))
                                                                 .ToList();

        _viewModel.Divisions = divisions;
        _viewModel.SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveTeamDivision.Command(TeamId, _viewModel.Divisions));
    }
}
