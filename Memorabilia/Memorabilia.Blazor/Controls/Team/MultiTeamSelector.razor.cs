#nullable disable

namespace Memorabilia.Blazor.Controls.Team;

public partial class MultiTeamSelector : ComponentBase
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public bool CanToggle { get; set; }

    [Parameter]
    public ItemType ItemType { get; set; }

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    [Parameter]
    public SaveTeamViewModel SelectedTeam { get; set; }

    [Parameter]
    public EventCallback<SaveTeamViewModel> SelectedTeamChanged { get; set; }

    [Parameter]
    public List<SaveTeamViewModel> Teams { get; set; } = new();

    SaveTeamViewModel _viewModel
    {
        get => SelectedTeam;
        set
        {
            SelectedTeam = value;
            SelectedTeamChanged.InvokeAsync(value);
        }
    }

    private bool _displayTeams;
    private bool _hasTeams;
    private string _itemTypeNameLabel => $"Associate {ItemType.Name} with Teams";

    protected override void OnInitialized()
    {
        _displayTeams = !CanToggle || SelectedTeam?.Id > 0 || Teams.Any();
        _hasTeams = SelectedTeam?.Id > 0 || Teams.Any();
    }

    private void Add()
    {
        var team = Teams.SingleOrDefault(team => team.Id == _viewModel.Id);

        if (team != null)
            team.IsDeleted = false;
        else
            Teams.Add(_viewModel);

        _viewModel = new();
    }

    private void TeamCheckboxClicked(bool isChecked)
    {
        _displayTeams = CanToggle && isChecked;

        if (!_displayTeams)
            SelectedTeam = null;

        _hasTeams = isChecked;
    }
}
