namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PersonTeamAutoComplete 
    : NamedEntityAutoComplete<PersonTeamEditModel>, INotifyPropertyChanged
{
    [Parameter]
    public int? BeginYear { get; set; }

    [Parameter]
    public int? EndYear { get; set; }

    [Parameter]
    public int PersonId { get; set; }

    [Parameter]
    public int[] SportIds { get; set; } 
        = [];

#pragma warning disable CS0067
    public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

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
        var model = new TeamsModel(await Mediator.Send(new GetTeams()));

        Items = model.Teams
                     .Select(team => new PersonTeamEditModel(PersonId, team));

        if (SportIds.Length != 0)
        {
            Items = Items.Where(team => SportIds.Contains(team.SportId));
        }

        if (BeginYear.HasValue || EndYear.HasValue)
        {
            if (!EndYear.HasValue)
            {
                Items = Items.Where(team => BeginYear >= team.BeginYear && 
                                            !team.EndYear.HasValue);
                return;
            }

            Items = Items.Where(team => (!BeginYear.HasValue || BeginYear == 0 || BeginYear >= team.BeginYear) && 
                                        (!team.EndYear.HasValue || EndYear <= team.EndYear));
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
