namespace Memorabilia.Web.Pages.User;

public partial class ViewRegister : WebPage
{
    protected void OnSaved()
    {
        NavigationManager.NavigateTo("/");
    }
}
