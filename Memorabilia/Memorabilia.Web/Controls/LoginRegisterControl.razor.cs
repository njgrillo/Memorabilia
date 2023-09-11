namespace Memorabilia.Web.Controls;

public partial class LoginRegisterControl
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected void Login()
    {
        //TODO redirect to login
    }

    protected void Register()
    {
        NavigationManager.NavigateTo("Register");
    }
}
