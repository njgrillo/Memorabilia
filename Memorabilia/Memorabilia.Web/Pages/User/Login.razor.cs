namespace Memorabilia.Web.Pages.User;

public partial class Login : WebPage
{
    protected void UserValidated(int userId)
    {
        UserId = userId;
    }
}
