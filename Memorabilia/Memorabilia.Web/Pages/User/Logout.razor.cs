namespace Memorabilia.Web.Pages.User
{
    public partial class Logout : ComponentBase
    {
        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        protected async Task LoggedOut()
        {
            await LocalStorage.DeleteAsync("UserId").ConfigureAwait(false);
        }
    }
}
