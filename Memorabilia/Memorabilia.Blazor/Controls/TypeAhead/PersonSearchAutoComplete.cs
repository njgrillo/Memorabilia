namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PersonSearchAutoComplete 
    : Autocomplete<Entity.Person>, INotifyPropertyChanged
{
    [Parameter]
    public bool IsCulturalSearch { get; set; } 
        = true;

    [Parameter]
    public Sport Sport { get; set; }

#pragma warning disable CS0067
    public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

    protected IEnumerable<Entity.Person> Items { get; set; } 
        = Enumerable.Empty<Entity.Person>();

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

    protected override string GetItemSelectedText(Entity.Person item)
        => item.Name;

    protected override string GetItemText(Entity.Person item)
        => item.Name;

    private async Task<IEnumerable<Entity.Person>> CulturalSearch(string searchText)
    {
        IEnumerable<Entity.Person> nonCulturalResults 
            = Items.Where(item => CultureInfo.CurrentCulture.CompareInfo.IndexOf(item.Name,
                                                                                 searchText,
                                                                                 CompareOptions.IgnoreNonSpace) > -1);

        IEnumerable<Entity.Person> culturalResults 
            = Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) || 
                                  item.LegalName.Contains(searchText, StringComparison.OrdinalIgnoreCase));

        return await Task.FromResult(nonCulturalResults.Union(culturalResults)
                                                       .DistinctBy(item => item.Name));
    }

    private async Task LoadItems()
    {
        Items = await Mediator.Send(new GetPeople(SportId: Sport?.Id ?? null));
    }

    private async void PersonAutoComplete_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Sport))
        {
            await LoadItems();
        }
    }

    public override async Task<IEnumerable<Entity.Person>> Search(string searchText)
    {
        if (searchText.IsNullOrEmpty())
            return Array.Empty<Entity.Person>();

        return IsCulturalSearch 
            ? await CulturalSearch(searchText)
            : await Task.FromResult(Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) || 
                                                        item.LegalName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                                         .DistinctBy(item => item.Name));
    }
}
