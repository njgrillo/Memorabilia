#nullable disable

namespace Memorabilia.Blazor.Controls
{
    public partial class Page : ComponentBase
    {
        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string ConfirmationTitle { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public EventCallback OnLoad { get; set; }

        private bool PageLoaded;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
                return;

            var userId = await LocalStorage.GetAsync<int>("UserId");

            if (userId.Value == 0)
                NavigationManager.NavigateTo("Login");
        }

        protected override async Task OnInitializedAsync()
        {
            await OnLoad.InvokeAsync().ConfigureAwait(false);

            PageLoaded = true;
        }
    }
}
