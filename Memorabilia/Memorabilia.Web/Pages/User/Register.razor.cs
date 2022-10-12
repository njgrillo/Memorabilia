namespace Memorabilia.Web.Pages.User;

public partial class Register : WebPage
{
    protected void OnSaved(int userId)
    {
        UserId = userId;
    }
}
