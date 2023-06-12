namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PersonSearchAutoComplete : Autocomplete<Domain.Entities.Person>, INotifyPropertyChanged
{
    [Parameter]
    public bool IsCulturalSearch { get; set; } = true;

    [Parameter]
    public Sport Sport { get; set; }

#pragma warning disable CS0067
    public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

    protected IEnumerable<Domain.Entities.Person> Items { get; set; } = Enumerable.Empty<Domain.Entities.Person>();

    public PersonSearchAutoComplete()
    {
        PropertyChanged += PersonAutoComplete_PropertyChanged;
    }

    protected override async Task OnInitializedAsync()
    {
        Label = "Person";
        Placeholder = "Search by name...";

        await LoadItems();
    }

    protected override string GetItemSelectedText(Domain.Entities.Person item)
    {
        return item.Name;
    }

    protected override string GetItemText(Domain.Entities.Person item)
    {
        return item.Name;
    }

    private async Task<IEnumerable<Domain.Entities.Person>> CulturalSearch(string searchText)
    {
        var nonCulturalResults = Items.Where(item => CultureInfo.CurrentCulture.CompareInfo.IndexOf(item.Name,
                                                                                                    searchText,
                                                                                                    CompareOptions.IgnoreNonSpace) > -1);

        var culturalResults = Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                                               || item.LegalName.Contains(searchText, StringComparison.OrdinalIgnoreCase));

        return await Task.FromResult(nonCulturalResults.Union(culturalResults)
                                                       .DistinctBy(item => item.Name));
    }

    private async Task LoadItems()
    {
        Items = await QueryRouter.Send(new GetPeople(SportId: Sport?.Id ?? null));
    }

    private async void PersonAutoComplete_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Sport))
        {
            await LoadItems();
        }
    }

    public override async Task<IEnumerable<Domain.Entities.Person>> Search(string searchText)
    {
        if (searchText.IsNullOrEmpty())
            return Array.Empty<Domain.Entities.Person>();

        if (IsCulturalSearch)
            return await CulturalSearch(searchText);
        else
            return await Task.FromResult(Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) 
                                                          || item.LegalName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                                              .DistinctBy(item => item.Name));
    }
}
