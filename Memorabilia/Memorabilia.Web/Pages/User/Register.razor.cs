namespace Memorabilia.Web.Pages.User
{
    public partial class Register : ComponentBase
    {
        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        protected async Task OnSaved(int userId)
        {
            await LocalStorage.SetAsync("UserId", userId).ConfigureAwait(false);
        }
    }
}
