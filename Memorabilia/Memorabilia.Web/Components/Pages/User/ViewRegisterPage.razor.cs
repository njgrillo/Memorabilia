namespace Memorabilia.Web.Components.Pages.User;

public partial class ViewRegisterPage : WebPage
{
    protected void OnSaved()
    {
        NavigationManager.NavigateTo("/");
    }
}
