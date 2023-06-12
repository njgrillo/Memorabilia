namespace Memorabilia.Blazor.Controls.TypeAhead;

public class NamedEntityAutoComplete<T> 
    : Autocomplete<T> where T : Model, IWithName, IWithValue<int>
{
    [Parameter]
    public bool IsCulturalSearch { get; set; }

    protected IEnumerable<T> Items { get; set; } 
        = Enumerable.Empty<T>();

    protected override string GetItemSelectedText(T item)
        => item.Name;

    protected override string GetItemText(T item)
        => item.Name;

    public override async Task<IEnumerable<T>> Search(string searchText)
    {
        if (searchText.IsNullOrEmpty())
            return Array.Empty<T>();

        return IsCulturalSearch 
            ? await CulturalSearch(searchText)
            : await Task.FromResult(Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)));
    }

    private async Task<IEnumerable<T>> CulturalSearch(string searchText)
    {
        IEnumerable<T> nonCulturalResults 
            = Items.Where(item => CultureInfo.CurrentCulture.CompareInfo.IndexOf(item.Name,
                                                                                 searchText,
                                                                                 CompareOptions.IgnoreNonSpace) > -1);

        IEnumerable<T> culturalResults 
            = Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase));

        return await Task.FromResult(nonCulturalResults.Union(culturalResults)
                                                       .DistinctBy(item => item.Name));
    }
}
