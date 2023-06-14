namespace Memorabilia.Web.Controls;

public partial class RegisterControl
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected void Register()
    {
        NavigationManager.NavigateTo("Register");
    }
}
