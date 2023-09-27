namespace Memorabilia.Blazor.Controls.TypeAhead;

public class UsernameAutoComplete : NamedEntityAutoComplete<UserModel>
{
    protected override async Task OnInitializedAsync()
    {
        Label = "User";
        Placeholder = "Search by username...";

        await LoadItems();
    }

    private async Task LoadItems()
    {
        Entity.User[] users = await QueryRouter.Send(new GetUsers());

        Items = users.Select(user => new UserModel(user));
    }
}
