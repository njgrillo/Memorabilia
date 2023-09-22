namespace Memorabilia.Blazor.Controls.TypeAhead;

public class UsernameAutoComplete : NamedEntityAutoComplete<UserModel>
{
    protected override async Task OnInitializedAsync()
    {
        Label = "User";
        Placeholder = "Search by username...";

        await LoadItems();
    }

    protected override string GetItemSelectedText(UserModel item)
        => item.Username;

    protected override string GetItemText(UserModel item)
        => item.Username;

    public override async Task<IEnumerable<UserModel>> Search(string searchText)
    {
        if (searchText.IsNullOrEmpty())
            return Array.Empty<UserModel>();

        IEnumerable<UserModel> nonCulturalResults
            = Items.Where(item => CultureInfo.CurrentCulture.CompareInfo.IndexOf(item.Name,
                                                                                 searchText,
                                                                                 CompareOptions.IgnoreNonSpace) > -1);

        IEnumerable<UserModel> culturalResults
            = Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase));

        return await Task.FromResult(nonCulturalResults.Union(culturalResults)
                                                       .DistinctBy(item => item.Name));
    }

    private async Task LoadItems()
    {
        Entity.User[] users = await QueryRouter.Send(new GetUsers());

        Items = users.Select(user => new UserModel(user));
    }
}
