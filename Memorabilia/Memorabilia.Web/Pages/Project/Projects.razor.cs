namespace Memorabilia.Web.Pages.Project
{
    public partial class Projects : ComponentBase
    {
        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        protected int UserId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var userId = await LocalStorage.GetAsync<int>("UserId").ConfigureAwait(false);

            UserId = userId.Value;
        }
    }
}
