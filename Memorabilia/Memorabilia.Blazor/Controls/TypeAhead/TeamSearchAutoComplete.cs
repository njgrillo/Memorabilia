namespace Memorabilia.Blazor.Controls.TypeAhead;

public class TeamSearchAutoComplete : Autocomplete<Domain.Entities.Team>, INotifyPropertyChanged
{
    [Parameter]
    public Sport Sport { get; set; }

#pragma warning disable CS0067
    public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

    protected IEnumerable<Domain.Entities.Team> Items { get; set; } = Enumerable.Empty<Domain.Entities.Team>();

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

    protected override string GetItemSelectedText(Domain.Entities.Team item)
    {
        return item.DisplayName;
    }

    protected override string GetItemText(Domain.Entities.Team item)
    {
        return item.DisplayName;
    }

    private async Task LoadItems()
    {
        Items = await QueryRouter.Send(new GetDomainTeams(Sport?.Id ?? null));
    }

    private async void TeamSearchAutoComplete_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Sport))
        {
            await LoadItems();
        }
    }

    public override async Task<IEnumerable<Domain.Entities.Team>> Search(string searchText)
    {
        if (searchText.IsNullOrEmpty())
            return Array.Empty<Domain.Entities.Team>();

        return await Task.FromResult(Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                                                      || item.Location.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                                                      || item.DisplayName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                                          .DistinctBy(item => item.ToString()));
    }
}
