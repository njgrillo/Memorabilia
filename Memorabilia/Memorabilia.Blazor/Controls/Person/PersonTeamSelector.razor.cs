#nullable disable

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonTeamSelector : ComponentBase
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int PersonId { get; set; }

    [Parameter]
    public int[] SportIds { get; set; } = Array.Empty<int>();

    [Parameter]
    public List<SavePersonTeamViewModel> Teams { get; set; } = new();

    private bool _canAdd = true;
    private bool _canEditTeam = true;
    private bool _canUpdate;
    private IEnumerable<SavePersonTeamViewModel> _teams = Enumerable.Empty<SavePersonTeamViewModel>();
    private SavePersonTeamViewModel _viewModel = new();

    protected override async Task OnInitializedAsync()
    {
        await LoadTeams().ConfigureAwait(false);
    }

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

    private async Task LoadTeams()
    {
        var query = new GetTeams.Query();

        _teams = (await QueryRouter.Send(query).ConfigureAwait(false)).Teams.Select(team => new SavePersonTeamViewModel(PersonId, team));

        if (SportIds.Any())
        {
            _teams = _teams.Where(team => SportIds.Contains(team.SportId));
        }
    }

    private void Remove(int teamPersonId)
    {
        var team = Teams.SingleOrDefault(team => team.Id == teamPersonId);

        if (team == null)
            return;

        team.IsDeleted = true;
    }

    private async Task<IEnumerable<SavePersonTeamViewModel>> SearchTeams(string searchText)
    {
        if (searchText.IsNullOrEmpty())
            return Array.Empty<SavePersonTeamViewModel>();

        return await Task.FromResult(_teams.Where(team => team.TeamDisplayName.Contains(searchText, StringComparison.OrdinalIgnoreCase))).ConfigureAwait(false);
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
