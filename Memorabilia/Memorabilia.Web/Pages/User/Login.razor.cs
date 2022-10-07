namespace Memorabilia.Web.Pages.User
{
    public partial class Login : ComponentBase
    {
        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        protected async Task UserValidated(int userId)
        {
            await LocalStorage.SetAsync("UserId", userId).ConfigureAwait(false);
        }
    }
}
