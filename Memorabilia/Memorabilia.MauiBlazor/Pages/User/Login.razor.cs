namespace Memorabilia.MauiBlazor.Pages.User;

public partial class Login : DesktopPage
{
    protected void UserValidated(int userId)
    {
        UserId = userId;
    }
}
