namespace Memorabilia.Blazor.Controls.TypeAhead;

public class CollegeAutoComplete : DomainEntityAutoComplete<College>
{
    protected override void OnInitialized()
    {
        Label = "College";
        Placeholder = "Search by college...";
        ResetValueOnEmptyText = true;
        Items = College.All;
    }

    public override async Task<IEnumerable<College>> Search(string searchText)
    {
        if (searchText.IsNullOrEmpty())
            return Array.Empty<College>();

        return await Task.FromResult(Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                                                      || (!item.Abbreviation.IsNullOrEmpty() && item.Abbreviation.Contains(searchText, StringComparison.OrdinalIgnoreCase))));
    }
}
