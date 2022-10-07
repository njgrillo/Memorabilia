#nullable disable

namespace Memorabilia.Web.Controls
{
    public partial class WebPage : ComponentBase
    {
        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        private bool PageLoaded;

        protected override async Task OnInitializedAsync()
        {
            var userId = await LocalStorage.GetAsync<int>("UserId").ConfigureAwait(false);

            if (userId.Value == 0)
                NavigationManager.NavigateTo("Login");

            PageLoaded = true;
        }
    }
}
