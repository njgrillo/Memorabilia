namespace Memorabilia.Blazor.Controls.TypeAhead;

public class TeamAutoComplete : NamedEntityAutoComplete<SaveTeamViewModel>, INotifyPropertyChanged
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

    protected override string GetItemSelectedText(SaveTeamViewModel item)
    {
        return item.DisplayName;
    }

    protected override string GetItemText(SaveTeamViewModel item)
    {
        return item.DisplayName;
    }

    private async Task LoadItems()
    {
        Items = (await QueryRouter.Send(new GetTeams(SportLeagueLevelId: SportLeagueLevel?.Id, SportId: Sport?.Id))).Teams.Select(team => new SaveTeamViewModel(team));
    }

    private async void TeamAutoComplete_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SportLeagueLevel) || e.PropertyName == nameof(Sport))
        {
            await LoadItems();
        }
    }
}
