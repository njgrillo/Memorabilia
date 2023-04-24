

namespace Memorabilia.Blazor.Controls.Team;

public partial class MultiTeamSelector : ComponentBase
{
    [Parameter]
    public bool CanToggle { get; set; }

    [Parameter]
    public ItemType ItemType { get; set; }

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    [Parameter]
    public List<SaveTeamViewModel> SelectedTeams { get; set; }

    [Parameter]
    public EventCallback<List<SaveTeamViewModel>> SelectedTeamsChanged { get; set; }

    protected SaveTeamViewModel SelectedTeam { get; set; }

    private bool _displayTeams;
    private bool _hasTeams;
    private string _itemTypeNameLabel => $"Associate {ItemType.Name} with Teams";

    protected override void OnInitialized()
    {
        _displayTeams = !CanToggle || SelectedTeams.Any();
        _hasTeams = SelectedTeams.Any();
    }

    private void Add()
    {
        var team = SelectedTeams.SingleOrDefault(team => team.Id == SelectedTeam.Id);

        if (team != null)
            team.IsDeleted = false;
        else
        {
            SelectedTeams.Add(SelectedTeam);
            SelectedTeamsChanged.InvokeAsync(SelectedTeams);
        }

        SelectedTeam = new();
    }

    private void TeamCheckboxClicked(bool isChecked)
    {
        _displayTeams = CanToggle && isChecked;

        if (!_displayTeams)
        {
            SelectedTeam = new();
            SelectedTeams = new();            
            SelectedTeamsChanged.InvokeAsync(SelectedTeams);
        }            

        _hasTeams = isChecked;
    }
}
