#nullable disable

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonTeamSelector : ComponentBase
{
    [Parameter]
    public int PersonId { get; set; }

    [Parameter]
    public int[] SportIds { get; set; } = Array.Empty<int>();

    [Parameter]
    public List<SavePersonTeamViewModel> Teams { get; set; } = new();

    private bool _canAdd = true;
    private bool _canEditTeam = true;
    private bool _canUpdate;
    private SavePersonTeamViewModel _viewModel = new();

    private void Add()
    {
        Teams.Add(_viewModel);

        _viewModel = new SavePersonTeamViewModel();
    }

    private void Edit(SavePersonTeamViewModel team)
    {
        _viewModel = team;

        _canAdd = false;
        _canEditTeam = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var team = _viewModel.Id > 0
            ? Teams.Single(team => team.Id == _viewModel.Id)
            : Teams.Single(team => team.TeamId == _viewModel.TeamId && team.TeamRoleTypeId == _viewModel.TeamRoleTypeId);

        team.BeginYear = _viewModel.BeginYear;
        team.EndYear = _viewModel.EndYear;
        team.TeamRoleTypeId = _viewModel.TeamRoleTypeId;

        _viewModel = new SavePersonTeamViewModel();

        _canAdd = true;
        _canEditTeam = true;
        _canUpdate = false;
    }
}
