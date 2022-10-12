namespace Memorabilia.Web.Pages.User;

public partial class Logout : WebPage
{
    protected async Task LoggedOut()
    {
        await DeleteUserId();   
    }
}
