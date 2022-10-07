namespace Memorabilia.Web.Pages.User
{
    public partial class ManageDashboard : ComponentBase
    {
        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        private int UserId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var userId = await LocalStorage.GetAsync<int>("UserId").ConfigureAwait(false);

            UserId = userId.Value;
        }
    }
}
