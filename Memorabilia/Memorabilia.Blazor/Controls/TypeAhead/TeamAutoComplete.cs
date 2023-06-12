namespace Memorabilia.Blazor.Controls.TypeAhead;

public class TeamAutoComplete 
    : NamedEntityAutoComplete<TeamEditModel>, INotifyPropertyChanged
{
    [Parameter]
    public Sport Sport { get; set; }

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

#pragma warning disable CS0067
    public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

    public TeamAutoComplete()
    {
        PropertyChanged += TeamAutoComplete_PropertyChanged;
    }

    protected override async Task OnInitializedAsync()
    {
        Label = "Team";
        Placeholder = "Search by team...";
        ResetValueOnEmptyText = true;

        await LoadItems();
    }

    protected override string GetItemSelectedText(TeamEditModel item)
        => item.DisplayName;

    protected override string GetItemText(TeamEditModel item)
        => item.DisplayName;

    private async Task LoadItems()
    {
        Entity.Team[] teams 
            = await QueryRouter.Send(new GetTeams(SportLeagueLevelId: SportLeagueLevel?.Id, 
                                                  SportId: Sport?.Id));

        Items = teams.Select(team => new TeamEditModel(new TeamModel(team)));
    }

    private async void TeamAutoComplete_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SportLeagueLevel) || e.PropertyName == nameof(Sport))
        {
            await LoadItems();
        }
    }
}
