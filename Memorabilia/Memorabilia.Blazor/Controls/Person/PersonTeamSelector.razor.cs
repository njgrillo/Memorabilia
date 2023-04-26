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
    private SavePersonTeamViewModel _selectedTeam = new();
    private SavePersonTeamViewModel _viewModel = new();

    private void Add()
    {
        if (_selectedTeam.TeamId == 0)
            return;

        _viewModel.TeamId = _selectedTeam.TeamId;
        _viewModel.FranchiseName = _selectedTeam.FranchiseName;
        _viewModel.TeamLocation = _selectedTeam.TeamLocation;
        _viewModel.TeamName = _selectedTeam.TeamName;

        Teams.Add(_viewModel);

        _selectedTeam = new();
        _viewModel = new();
    }

    private void Edit(SavePersonTeamViewModel team)
    {
        _selectedTeam = team;
        _viewModel = team;

        _canAdd = false;
        _canEditTeam = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var team = _viewModel.Id > 0
            ? Teams.Single(team => team.Id == _viewModel.Id)
            : Teams.Single(team => team.TeamId == _viewModel.TeamId && team.TeamRoleType.Id == _viewModel.TeamRoleType.Id);

        team.BeginYear = _viewModel.BeginYear;
        team.EndYear = _viewModel.EndYear;
        team.TeamRoleType = _viewModel.TeamRoleType;

        _selectedTeam = new();
        _viewModel = new();

        _canAdd = true;
        _canEditTeam = true;
        _canUpdate = false;
    }
}
