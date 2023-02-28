namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PersonTeamAutoComplete : NamedEntityAutoComplete<SavePersonTeamViewModel>, INotifyPropertyChanged
{
    [Parameter]
    public int? BeginYear { get; set; }

    [Parameter]
    public int? EndYear { get; set; }

    [Parameter]
    public int PersonId { get; set; }

    [Parameter]
    public int[] SportIds { get; set; } = Array.Empty<int>();

    public event PropertyChangedEventHandler PropertyChanged;

    public PersonTeamAutoComplete()
    {
        PropertyChanged += PersonTeamAutoComplete_PropertyChanged;
    }

    protected override async Task OnInitializedAsync()
    {
        Label = "Team";
        Placeholder = "Search by team...";
        ResetValueOnEmptyText = true;

        await LoadItems();
    }

    private async Task LoadItems()
    {
        var items = await QueryRouter.Send(new GetTeams());

        Items = items.Teams.Select(team => new SavePersonTeamViewModel(PersonId, team));

        if (SportIds.Any())
        {
            Items = Items.Where(team => SportIds.Contains(team.SportId));
        }

        if (BeginYear.HasValue || EndYear.HasValue)
        {
            if (!EndYear.HasValue)
            {
                Items = Items.Where(team => BeginYear >= team.BeginYear
                                                        && !team.EndYear.HasValue);
                return;
            }

            Items = Items.Where(team => (!BeginYear.HasValue || BeginYear == 0 || BeginYear >= team.BeginYear)
                                     && (!team.EndYear.HasValue || EndYear <= team.EndYear));
        }
    }

    private async void PersonTeamAutoComplete_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(BeginYear) || e.PropertyName == nameof(EndYear))
        {
            await LoadItems();
        }
    }
}
