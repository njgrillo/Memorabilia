namespace Memorabilia.Blazor.Pages.User;

public partial class Logout
{   
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public EventCallback LoggedOut { get; set; }

    protected async Task OnLoad()
    {
        NavigationManager.NavigateTo("Login");

        await LoggedOut.InvokeAsync();
    }
}
