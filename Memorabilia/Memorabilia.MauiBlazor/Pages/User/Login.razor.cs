namespace Memorabilia.MauiBlazor.Pages.User
{
    public partial class Login : ComponentBase
    {
        protected async Task UserValidated(int userId)
        {
            await SecureStorage.Default.SetAsync("UserId", userId.ToString());
        }
    }
}
