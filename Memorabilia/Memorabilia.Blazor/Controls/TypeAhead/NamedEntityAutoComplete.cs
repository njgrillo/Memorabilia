#nullable disable

namespace Memorabilia.Blazor.Controls.TypeAhead;

public class NamedEntityAutoComplete<T> : Autocomplete<T> where T : ViewModel, IWithName, IWithValue<int>
{
    [Parameter]
    public bool IsCulturalSearch { get; set; }

    protected IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();

    protected override string GetItemSelectedText(T item)
    {
        return item.Name;
    }

    protected override string GetItemText(T item)
    {
        return item.Name;
    }

    public override async Task<IEnumerable<T>> Search(string searchText)
    {
        if (searchText.IsNullOrEmpty())
            return Array.Empty<T>();

        if (IsCulturalSearch)
            return await CulturalSearch(searchText);
        else
            return await Task.FromResult(Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)));
    }

    private async Task<IEnumerable<T>> CulturalSearch(string searchText)
    {
        var nonCulturalResults = Items.Where(item => CultureInfo.CurrentCulture.CompareInfo.IndexOf(item.Name,
                                                                                                    searchText,
                                                                                                    CompareOptions.IgnoreNonSpace) > -1);

        var culturalResults = Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase));

        return await Task.FromResult(nonCulturalResults.Union(culturalResults).DistinctBy(item => item.Name));
    }
}
