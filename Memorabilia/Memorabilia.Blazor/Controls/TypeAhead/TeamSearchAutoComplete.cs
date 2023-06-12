namespace Memorabilia.Blazor.Controls.TypeAhead;

public class TeamSearchAutoComplete 
    : Autocomplete<Entity.Team>, INotifyPropertyChanged
{
    [Parameter]
    public Sport Sport { get; set; }

#pragma warning disable CS0067
    public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

    protected IEnumerable<Entity.Team> Items { get; set; } 
        = Enumerable.Empty<Entity.Team>();

    public TeamSearchAutoComplete()
    {
        PropertyChanged += TeamSearchAutoComplete_PropertyChanged;
    }

    protected override async Task OnInitializedAsync()
    {
        Label = "Team";
        Placeholder = "Search by team...";

        await LoadItems();
    }

    protected override string GetItemSelectedText(Entity.Team item)
        => item.DisplayName;

    protected override string GetItemText(Entity.Team item)
        => item.DisplayName;

    private async Task LoadItems()
    {
        Items = await QueryRouter.Send(new GetTeams(SportId: Sport?.Id ?? null));
    }

    private async void TeamSearchAutoComplete_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Sport))
        {
            await LoadItems();
        }
    }

    public override async Task<IEnumerable<Entity.Team>> Search(string searchText)
        => !searchText.IsNullOrEmpty()
            ? await Task.FromResult(Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) || 
                                                item.Location.Contains(searchText, StringComparison.OrdinalIgnoreCase) || 
                                                item.DisplayName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                                         .DistinctBy(item => item.Id))
            : Array.Empty<Entity.Team>();
}
